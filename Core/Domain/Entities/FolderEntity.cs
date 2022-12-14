namespace CloudIn.Core.Domain.Entities;

public class FolderEntity : IBaseEntity
{
    public FolderEntity()
    {
        Files = new HashSet<FileEntity>();
        Folders = new HashSet<FolderEntity>();
    }

    public new Guid Id { get; set; } = Guid.NewGuid();

    public Guid OwnerUserId { get; protected set; } = default!;

    public Guid? ParentFolderId { get; protected set; }

    public string Name { get; set; } = default!;

    public bool IsRootFolder { get; protected set; } = false;

    public virtual ICollection<FileEntity> Files { get; protected set; } = default!;

    public virtual ICollection<FolderEntity> Folders { get; set; } = default!;

    public void SetAsRootFolder(UserEntity ownerUser)
    {
        OwnerUserId = ownerUser.Id;
        ParentFolderId = null;
        IsRootFolder = true;
        Name = $"Root:{ownerUser.Id}";
    }

    public void SetAsChildFolder(FolderEntity parentFolder, UserEntity ownerUser)
    {
        OwnerUserId = ownerUser.Id;
        ParentFolderId = parentFolder.Id;
        IsRootFolder = false;
    }

    public void AddFile(FileEntity file) => Files.Add(file);
}
