using CloudIn.Core.Domain.Entities;
using CloudIn.Core.Domain.Services.FolderService;
using CloudIn.Core.Domain.Services.FolderService.Interfaces;

namespace CloudIn.Core.DomainTests.Services;

public partial class FolderServiceTests
{
    [TestMethod]
    public async Task Should_Create_A_Folder_On_Root_Directory()
    {
        var folderService = new FolderService(_mapper, _folderRepository, _userRepository);

        ICreateFolderPayload folderPayload =
            new()
            {
                OwnerUserId = _user.Id,
                ParentFolderId = _user.RootFolderId ?? Guid.Empty,
                Name = "Documents"
            };

        var folder = await folderService.CreateFolderAsync(folderPayload);

        Assert.IsNotNull(folder);
        Assert.IsInstanceOfType(folder, typeof(FolderEntity));
        Assert.AreEqual(folderPayload.Name, folder.Name);
        Assert.AreEqual(folderPayload.OwnerUserId, folder.OwnerUserId);
        Assert.AreEqual(folderPayload.ParentFolderId, folder.ParentFolderId);
        Assert.AreEqual(2, _folderRepository.Folders.Count); // Should have parent and child folder
        Assert.IsFalse(folder.IsRootFolder);
    }
}
