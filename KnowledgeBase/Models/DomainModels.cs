using System;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeBase.Domain;

public enum UserRole { ProjectManager, Member }

public sealed class User
{
    public int Id { get; }
    public string Name { get; }
    public UserRole Role { get; }

    public User(int id, string name, UserRole role)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Role = role;
    }

    public override string ToString() => $"{Name} ({Role})";
}

public sealed class Tag
{
    public string Name { get; }

    public Tag(string name)
    {
        Name = (name ?? "").Trim();
        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("Der Tag-Name darf nicht leer sein.");
    }

    public override bool Equals(object? obj) =>
        obj is Tag other && string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);

    public override int GetHashCode() =>
        StringComparer.OrdinalIgnoreCase.GetHashCode(Name);

    public override string ToString() => Name;
}

public sealed class Comment
{
    public User Author { get; }
    public string Text { get; }
    public DateTime CreatedAt { get; }

    public Comment(User author, string text, DateTime? createdAt = null)
    {
        Author = author ?? throw new ArgumentNullException(nameof(author));
        Text = text ?? throw new ArgumentNullException(nameof(text));
        CreatedAt = createdAt ?? DateTime.UtcNow;
    }

    public override string ToString() => $"{CreatedAt:g} {Author.Name}: {Text}";
}

public sealed class Revision
{
    public User Author { get; }
    public string AddedText { get; }
    public DateTime CreatedAt { get; }

    public Revision(User author, string addedText, DateTime? createdAt = null)
    {
        Author = author ?? throw new ArgumentNullException(nameof(author));
        AddedText = addedText ?? throw new ArgumentNullException(nameof(addedText));
        CreatedAt = createdAt ?? DateTime.UtcNow;
    }
}

public abstract class Information
{
    private readonly List<Tag> _tags = new();
    private readonly List<Comment> _comments = new();

    public int Id { get; }
    public string Title { get; }
    public User Author { get; }
    public DateTime CreatedAt { get; }

    public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    public abstract string Kind { get; }

    protected Information(int id, string title, User author, DateTime? createdAt = null)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Der Titel darf nicht leer sein.", nameof(title));

        Id = id;
        Title = title;
        Author = author ?? throw new ArgumentNullException(nameof(author));
        CreatedAt = createdAt ?? DateTime.UtcNow;
    }

    public void AddTag(Tag tag)
    {
        if (tag is null) throw new ArgumentNullException(nameof(tag));
        if (_tags.Contains(tag)) return;
        _tags.Add(tag);
    }

    public void AddComment(Comment comment)
    {
        if (comment is null) throw new ArgumentNullException(nameof(comment));
        _comments.Add(comment);
    }

    public string TagsAsString() => string.Join(", ", _tags.Select(t => t.Name));
}

public sealed class TextInformation : Information
{
    private readonly List<Revision> _revisions = new();

    public string Content { get; private set; }
    public IReadOnlyCollection<Revision> Revisions => _revisions.AsReadOnly();

    public override string Kind => "Text";

    public TextInformation(int id, string title, User author, string content, DateTime? createdAt = null)
        : base(id, title, author, createdAt)
    {
        Content = content ?? throw new ArgumentNullException(nameof(content));
    }

    public void AddRevision(Revision revision)
    {
        if (revision is null) throw new ArgumentNullException(nameof(revision));
        _revisions.Add(revision);
        Content += Environment.NewLine + revision.AddedText;
    }
}

public sealed class ImageInformation : Information
{
    public string Url { get; }

    public override string Kind => "Image";

    public ImageInformation(int id, string title, User author, string url, DateTime? createdAt = null)
        : base(id, title, author, createdAt)
    {
        Url = url ?? throw new ArgumentNullException(nameof(url));
    }
}

public sealed class DocumentInformation : Information
{
    public string Url { get; }

    public override string Kind => "Document";

    public DocumentInformation(int id, string title, User author, string url, DateTime? createdAt = null)
        : base(id, title, author, createdAt)
    {
        Url = url ?? throw new ArgumentNullException(nameof(url));
    }
}

public sealed class Project
{
    private readonly List<Information> _informations = new();

    public int Id { get; }
    public string Name { get; }
    public string Customer { get; }
    public string CoreRequirements { get; }
    public User ProjectManager { get; }

    public IReadOnlyCollection<Information> Informations => _informations.AsReadOnly();

    public Project(int id, string name, string customer, string coreRequirements, User projectManager)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Der Projektname darf nicht leer sein.", nameof(name));
        if (string.IsNullOrWhiteSpace(customer))
            throw new ArgumentException("Der Kunde darf nicht leer sein.", nameof(customer));

        Id = id;
        Name = name;
        Customer = customer;
        CoreRequirements = coreRequirements ?? string.Empty;
        ProjectManager = projectManager ?? throw new ArgumentNullException(nameof(projectManager));
    }

    public void AddInformation(Information info)
    {
        if (info is null) throw new ArgumentNullException(nameof(info));
        if (_informations.Any(i => i.Id == info.Id))
            throw new InvalidOperationException($"Eine Information mit der ID {info.Id} existiert im Projekt {Id} bereits.");

        _informations.Add(info);
    }

    public void RemoveInformation(int infoId)
    {
        var item = _informations.FirstOrDefault(i => i.Id == infoId);
        if (item != null)
            _informations.Remove(item);
    }

    public IEnumerable<Information> FindInformationByTag(string tagName)
    {
        if (string.IsNullOrWhiteSpace(tagName))
            return Enumerable.Empty<Information>();

        return _informations.Where(i =>
            i.Tags.Any(t => string.Equals(t.Name, tagName, StringComparison.OrdinalIgnoreCase)));
    }

    public override string ToString() => $"{Id}: {Name} ({Customer})";
}