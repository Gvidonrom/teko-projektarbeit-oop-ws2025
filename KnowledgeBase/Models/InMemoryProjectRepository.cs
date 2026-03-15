using System.Collections.Generic;
using System.Linq;
using KnowledgeBase.Application;
using KnowledgeBase.Domain;

namespace KnowledgeBase.Infrastructure;

public sealed class InMemoryProjectRepository : IProjectRepository
{
    private readonly Dictionary<int, Project> _store = new();

    public Project? GetById(int id) => _store.TryGetValue(id, out var p) ? p : null;

    public IReadOnlyList<Project> GetAll() => _store.Values.OrderBy(p => p.Id).ToList();

    public void Save(Project project) => _store[project.Id] = project;

    public void Delete(int projectId) => _store.Remove(projectId);

    public void Clear() => _store.Clear();
}