using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using KnowledgeBase.Application;
using KnowledgeBase.Domain;
using KnowledgeBase.Infrastructure;
using KnowledgeBase.WpfApp;
using KnowledgeBase.WpfApp.Mvvm;

namespace KnowledgeBase.WpfApp.ViewModels;

public sealed class MainViewModel : ObservableObject
{
    private readonly InMemoryProjectRepository _repo;
    private readonly ProjectService _projectService;
    private readonly InformationService _infoService;

    public ObservableCollection<Project> Projects { get; } = new();
    public ObservableCollection<InformationListItem> ProjectInfos { get; } = new();
    public ObservableCollection<InformationListItem> SearchResults { get; } = new();
    public ObservableCollection<string> SelectedInfoComments { get; } = new();
    public ObservableCollection<string> SelectedInfoRevisions { get; } = new();

    private Project? _selectedProject;
    public Project? SelectedProject
    {
        get => _selectedProject;
        set
        {
            if (Set(ref _selectedProject, value))
            {
                RefreshProjectInfos();
                UpdateCommandStates();
            }
        }
    }

    // Create Project
    private int _nextProjectId = 1;

    private string _newProjectName = "Demo-Projekt";
    public string NewProjectName { get => _newProjectName; set => Set(ref _newProjectName, value); }

    private string _newCustomer = "Kunde AG";
    public string NewCustomer { get => _newCustomer; set => Set(ref _newCustomer, value); }

    private string _newCoreReq = "Kernanforderungen ...";
    public string NewCoreReq { get => _newCoreReq; set => Set(ref _newCoreReq, value); }

    private string _pmName = "Projektleiter";
    public string PmName { get => _pmName; set => Set(ref _pmName, value); }

    // Add Information
    private int _newInfoId = 1;
    public int NewInfoId { get => _newInfoId; set => Set(ref _newInfoId, value); }

    private string _infoTitle = "Titel";
    public string InfoTitle { get => _infoTitle; set => Set(ref _infoTitle, value); }

    private string _authorName = "Autor";
    public string AuthorName { get => _authorName; set => Set(ref _authorName, value); }

    private string _infoKind = "Text";
    public string InfoKind { get => _infoKind; set => Set(ref _infoKind, value); }
    public string[] InfoKindOptions { get; } = { "Text", "Bild (URL)", "Dokument (URL)" };

    private string _contentOrUrl = "";
    public string ContentOrUrl { get => _contentOrUrl; set => Set(ref _contentOrUrl, value); }

    private string _tagsCsv = "Analyse, Design, Anforderung";
    public string TagsCsv { get => _tagsCsv; set => Set(ref _tagsCsv, value); }

    // Comment / Revision
    private InformationListItem? _selectedInfo;
    public InformationListItem? SelectedInfo
    {
        get => _selectedInfo;
        set
        {
            if (Set(ref _selectedInfo, value))
            {
                RefreshSelectedInfoCommentsAndRevisions();
                UpdateCommandStates();
            }
        }
    }

    private string _commentText = "";
    public string CommentText { get => _commentText; set => Set(ref _commentText, value); }

    private string _revisionText = "";
    public string RevisionText { get => _revisionText; set => Set(ref _revisionText, value); }

    // Search
    private string _searchTag = "Design";
    public string SearchTag { get => _searchTag; set => Set(ref _searchTag, value); }

    public RelayCommand CreateProjectCommand { get; }
    public RelayCommand AddInformationCommand { get; }
    public RelayCommand AddCommentCommand { get; }
    public RelayCommand AddRevisionCommand { get; }
    public RelayCommand DeleteInformationCommand { get; }
    public RelayCommand DeleteProjectCommand { get; }
    public RelayCommand OpenInfoDetailCommand { get; }
    public RelayCommand SearchByTagCommand { get; }
    public RelayCommand LoadDemoCommand { get; }

    public MainViewModel()
    {
        _repo = new InMemoryProjectRepository();
        _projectService = new ProjectService(_repo);
        _infoService = new InformationService(_repo);

        CreateProjectCommand = new RelayCommand(CreateProject);
        AddInformationCommand = new RelayCommand(AddInformation, () => SelectedProject != null);
        AddCommentCommand = new RelayCommand(AddComment, () => SelectedProject != null && SelectedInfo != null);
        AddRevisionCommand = new RelayCommand(AddRevision, () => SelectedProject != null && SelectedInfo?.DomainObject is TextInformation);
        DeleteInformationCommand = new RelayCommand(DeleteInformation, () => SelectedProject != null && SelectedInfo != null);
        DeleteProjectCommand = new RelayCommand(DeleteProject, () => SelectedProject != null);
        OpenInfoDetailCommand = new RelayCommand(OpenInfoDetail);
        SearchByTagCommand = new RelayCommand(SearchByTag, () => SelectedProject != null);
        LoadDemoCommand = new RelayCommand(LoadDemo);

        LoadDemo();
        UpdateCommandStates();
    }

    private void UpdateCommandStates()
    {
        CreateProjectCommand.RaiseCanExecuteChanged();
        AddInformationCommand.RaiseCanExecuteChanged();
        AddCommentCommand.RaiseCanExecuteChanged();
        AddRevisionCommand.RaiseCanExecuteChanged();
        DeleteInformationCommand.RaiseCanExecuteChanged();
        DeleteProjectCommand.RaiseCanExecuteChanged();
        SearchByTagCommand.RaiseCanExecuteChanged();
    }

    private void ReloadProjects()
    {
        var selectedProjectId = _selectedProject?.Id;
        Projects.Clear();
        foreach (var p in _projectService.GetAllProjects())
            Projects.Add(p);

        if (selectedProjectId != null)
            SelectedProject = Projects.FirstOrDefault(p => p.Id == selectedProjectId.Value);
        if (SelectedProject == null && Projects.Count > 0)
            SelectedProject = Projects[0];
    }

    private void RefreshProjectInfos(int? preserveSelectedInfoId = null)
    {
        var idToRestore = preserveSelectedInfoId ?? _selectedInfo?.Id;
        ProjectInfos.Clear();
        SelectedInfo = null;

        if (SelectedProject == null) return;

        var p = _projectService.GetProject(SelectedProject.Id);
        foreach (var info in p.Informations)
            ProjectInfos.Add(new InformationListItem(info));

        if (idToRestore != null)
            SelectedInfo = ProjectInfos.FirstOrDefault(i => i.Id == idToRestore.Value);
    }

    private void RefreshSelectedInfoCommentsAndRevisions()
    {
        SelectedInfoComments.Clear();
        SelectedInfoRevisions.Clear();

        if (_selectedInfo?.DomainObject == null) return;

        foreach (var c in _selectedInfo.DomainObject.Comments)
            SelectedInfoComments.Add(c.ToString());

        if (_selectedInfo.DomainObject is TextInformation textInfo)
        {
            foreach (var r in textInfo.Revisions)
                SelectedInfoRevisions.Add($"{r.CreatedAt:g} {r.Author.Name}: {r.AddedText}");
        }
    }

    private static string MapInfoKindToService(string uiKind)
    {
        return uiKind switch
        {
            "Text" => "Text",
            "Bild (URL)" => "Image",
            "Dokument (URL)" => "Document",
            _ => uiKind
        };
    }

    private void CreateProject()
    {
        try
        {
            _projectService.CreateProject(new CreateProjectRequest(
                _nextProjectId, NewProjectName, NewCustomer, NewCoreReq,
                PmId: 1, PmName
            ));
            _nextProjectId++;
            ReloadProjects();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Fehler");
        }
    }

    private void AddInformation()
    {
        if (SelectedProject == null) return;

        try
        {
            var tags = (TagsCsv ?? "")
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Take(3)
                .ToList();

            if (tags.Count == 0)
            {
                MessageBox.Show("Bitte mindestens ein Tag angeben (z. B. Analyse, Design, Anforderung).", "Tags");
                return;
            }

            var kindForService = MapInfoKindToService(InfoKind);
            _projectService.AddInformation(new AddInformationRequest(
                SelectedProject.Id, NewInfoId, InfoTitle, AuthorId: 2, AuthorName,
                kindForService, ContentOrUrl, tags
            ));

            NewInfoId++;
            RefreshProjectInfos();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Fehler");
        }
    }

    private void AddComment()
    {
        if (SelectedProject == null || SelectedInfo == null) return;

        try
        {
            var infoId = SelectedInfo.Id;
            _infoService.AddComment(new AddCommentRequest(
                SelectedProject.Id, infoId, AuthorId: 3, AuthorName: AuthorName, Text: CommentText
            ));
            CommentText = "";
            RefreshProjectInfos(infoId);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Fehler");
        }
    }

    private void AddRevision()
    {
        if (SelectedProject == null || SelectedInfo == null) return;

        try
        {
            var infoId = SelectedInfo.Id;
            _infoService.AddRevision(new AddRevisionRequest(
                SelectedProject.Id, infoId, AuthorId: 3, AuthorName: AuthorName, AddedText: RevisionText
            ));
            RevisionText = "";
            RefreshProjectInfos(infoId);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Fehler");
        }
    }

    private void DeleteInformation()
    {
        if (SelectedProject == null || SelectedInfo == null) return;

        var title = SelectedInfo.Title;
        if (MessageBox.Show(
                $"Information \"{title}\" (Id {SelectedInfo.Id}) aus dem Projekt entfernen?",
                "Information löschen",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) != MessageBoxResult.Yes)
            return;

        try
        {
            _projectService.DeleteInformation(SelectedProject.Id, SelectedInfo.Id);
            RefreshProjectInfos();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Fehler");
        }
    }

    private void DeleteProject()
    {
        if (SelectedProject == null) return;

        var name = SelectedProject.Name;
        var id = SelectedProject.Id;
        if (MessageBox.Show(
                $"Projekt \"{name}\" (Id {id}) löschen? Alle zugehörigen Informationen werden gelöscht.",
                "Projekt löschen",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) != MessageBoxResult.Yes)
            return;

        try
        {
            _projectService.DeleteProject(id);
            SelectedProject = null;
            ReloadProjects();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Fehler");
        }
    }

    private void OpenInfoDetail(object? parameter)
    {
        if (parameter is not InformationListItem item) return;
        var w = new InfoDetailWindow(item.ContentOrUrl, item.Kind);
        w.Show();
    }

    private void SearchByTag()
    {
        if (SelectedProject == null) return;

        try
        {
            SearchResults.Clear();
            var results = _projectService.SearchByTag(SelectedProject.Id, SearchTag);
            foreach (var info in results)
                SearchResults.Add(new InformationListItem(info));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Fehler");
        }
    }

    private void LoadDemo()
    {
        _repo.Clear();
        _nextProjectId = 1;

        _projectService.CreateProject(new CreateProjectRequest(_nextProjectId, "Xarelto-Wissensmanagement-Prototyp", "Xarelto AG", "Wissensmanagement für Projekte", 1, "Projektleiter"));
        _nextProjectId++;
        _projectService.AddInformation(new AddInformationRequest(1, 1, "Anforderungsentwurf", 2, "Anna", "Text", "Erste Anforderungen ...", new[] { "Anforderung", "Analyse" }));
        _projectService.AddInformation(new AddInformationRequest(1, 2, "Architekturskizze", 2, "Bernd", "Image", "https://example.com/arch.png", new[] { "Design" }));
        _projectService.AddInformation(new AddInformationRequest(1, 3, "API-Spezifikation", 2, "Anna", "Document", "https://example.com/spec.pdf", new[] { "Design", "Dokument" }));

        ReloadProjects();
        RefreshProjectInfos();
    }
}