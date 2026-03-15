using System;
using System.Collections.Generic;
using System.Linq;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Application;

public sealed class ProjectService
{
    private readonly IProjectRepository _repo;

    public ProjectService(IProjectRepository repo) => _repo = repo;

    public IReadOnlyList<Project> GetAllProjects() => _repo.GetAll();

    public void DeleteProject(int projectId)
    {
        if (_repo.GetById(projectId) == null)
            throw new InvalidOperationException("Projekt nicht gefunden.");
        _repo.Delete(projectId);
    }

    public Project CreateProject(CreateProjectRequest req)
    {
        if (_repo.GetAll().Any(p =>
                string.Equals(p.Name, req.Name, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException(
                $"Ein Projekt mit dem Namen \"{req.Name}\" existiert bereits. Der Projektname muss eindeutig sein.");
        }

        var pm = new User(req.PmId, req.PmName, UserRole.ProjectManager);
        var p = new Project(req.ProjectId, req.Name, req.Customer, req.CoreRequirements, pm);
        _repo.Save(p);
        return p;
    }

    public void AddInformation(AddInformationRequest req)
    {
        var project = _repo.GetById(req.ProjectId) ?? throw new InvalidOperationException("Projekt nicht gefunden.");

        var author = new User(req.AuthorId, req.AuthorName, UserRole.Member);
        Information info = req.Kind switch
        {
            "Text" => new TextInformation(req.InfoId, req.Title, author, req.ContentOrUrl),
            "Image" => new ImageInformation(req.InfoId, req.Title, author, req.ContentOrUrl),
            "Document" => new DocumentInformation(req.InfoId, req.Title, author, req.ContentOrUrl),
            _ => throw new ArgumentException("Unbekannte Informationsart.")
        };

        var distinctTags = (req.Tags ?? Array.Empty<string>())
            .Select(t => (t ?? "").Trim())
            .Where(t => !string.IsNullOrWhiteSpace(t))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Take(3) // UI тоже ограничит, но тут безопасно
            .ToList();

        foreach (var t in distinctTags)
            info.AddTag(new Tag(t));

        project.AddInformation(info);
        _repo.Save(project);
    }

    public void DeleteInformation(int projectId, int infoId)
    {
        var project = _repo.GetById(projectId) ?? throw new InvalidOperationException("Projekt nicht gefunden.");
        project.RemoveInformation(infoId);
        _repo.Save(project);
    }

    public IReadOnlyList<Information> SearchByTag(int projectId, string tagName)
    {
        var project = _repo.GetById(projectId) ?? throw new InvalidOperationException("Projekt nicht gefunden.");
        return project.FindInformationByTag(tagName).ToList();
    }

    public Project GetProject(int id) => _repo.GetById(id) ?? throw new InvalidOperationException("Projekt nicht gefunden.");
}

public sealed class InformationService
{
    private readonly IProjectRepository _repo;

    public InformationService(IProjectRepository repo) => _repo = repo;

    public void AddComment(AddCommentRequest req)
    {
        var project = _repo.GetById(req.ProjectId) ?? throw new InvalidOperationException("Projekt nicht gefunden.");
        var info = project.Informations.FirstOrDefault(i => i.Id == req.InfoId)
                   ?? throw new InvalidOperationException("Information nicht gefunden.");

        var author = new User(req.AuthorId, req.AuthorName, UserRole.Member);
        info.AddComment(new Comment(author, req.Text));

        _repo.Save(project);
    }

    public void AddRevision(AddRevisionRequest req)
    {
        var project = _repo.GetById(req.ProjectId) ?? throw new InvalidOperationException("Projekt nicht gefunden.");
        var info = project.Informations.FirstOrDefault(i => i.Id == req.InfoId)
                   ?? throw new InvalidOperationException("Information nicht gefunden.");

        if (info is not TextInformation textInfo)
            throw new InvalidOperationException("Versionen sind nur für Textinformationen möglich.");

        var author = new User(req.AuthorId, req.AuthorName, UserRole.Member);
        textInfo.AddRevision(new Revision(author, req.AddedText));

        _repo.Save(project);
    }
}