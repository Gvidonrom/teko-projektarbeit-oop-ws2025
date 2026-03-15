using KnowledgeBase.Domain;

namespace KnowledgeBase.WpfApp.ViewModels;

public sealed class InformationListItem
{
    private const int InfoPreviewLength = 45;

    public int Id { get; }
    public string Kind { get; }
    public string KindDisplay => Kind switch
    {
        "Text" => "Text",
        "Image" => "Bild",
        "Document" => "Dokument",
        _ => Kind
    };
    public string Title { get; }
    public string Author { get; }
    public string CreatedAt { get; }
    public string Tags { get; }
    public string ContentOrUrl { get; } = string.Empty;
    public string InfoPreview { get; } = string.Empty;

    public Information DomainObject { get; }

    public InformationListItem(Information info)
    {
        DomainObject = info;
        Id = info.Id;
        Kind = info.Kind;
        Title = info.Title;
        Author = info.Author.Name;
        CreatedAt = info.CreatedAt.ToLocalTime().ToString("g");
        Tags = info.TagsAsString();
        ContentOrUrl = info switch
        {
            TextInformation t => t.Content,
            ImageInformation img => img.Url,
            DocumentInformation doc => doc.Url,
            _ => ""
        };

        var raw = ContentOrUrl ?? "";
        InfoPreview = raw.Length <= InfoPreviewLength ? raw : raw.Substring(0, InfoPreviewLength) + "...";
    }

    public override string ToString() => $"{Kind} #{Id} {Title}";
}