using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Models;

namespace Project.Services
{
    public interface IFolderService
    {
        IEnumerable<Folder> GetAllFolders();

        Folder GetFolder(string name);

        Folder GetFolder(int id);

        IEnumerable<Folder> RootFolders { get; } 

    }
}
