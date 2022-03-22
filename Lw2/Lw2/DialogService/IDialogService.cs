using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw2.DialogService
{
    public interface IDialogService
    {
        void ShowMessage(string message);   // показ сообщения
        string FilePath { get; }   // путь к выбранному файлу
        string FileName { get; }
        bool OpenFileDialog(string filter);  // открытие файла
        bool SaveFileDialog(string filter);  // сохранение файла
    }
}
