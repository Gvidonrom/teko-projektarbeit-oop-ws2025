using System.Collections.Generic;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Application;

public interface IProjectRepository
{
    Project? GetById(int id);
    IReadOnlyList<Project> GetAll();
    void Save(Project project);
    void Delete(int projectId);
}

public record CreateProjectRequest(int ProjectId, string Name, string Customer, string CoreRequirements, int PmId, string PmName);

public record AddInformationRequest(
    int ProjectId,
    int InfoId,
    string Title,
    int AuthorId,
    string AuthorName,
    string Kind,          // "Text" | "Image" | "Document"
    string ContentOrUrl,  // text content OR url
    IReadOnlyList<string> Tags
);

public record AddCommentRequest(int ProjectId, int InfoId, int AuthorId, string AuthorName, string Text);
public record AddRevisionRequest(int ProjectId, int InfoId, int AuthorId, string AuthorName, string AddedText);