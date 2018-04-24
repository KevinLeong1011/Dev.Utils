/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 20:40:50
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text;

namespace System.IO
{
    /// <summary>
    /// 
    /// </summary>
    public static class IOExtensions
    {
        #region FileInfo

        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="this"></param>
        /// <param name="newName"></param>
        public static void Rename(this FileInfo @this, string newName)
        {
            string extension = @this.Extension;
            if (!newName.EndsWith(extension)) newName += extension;
            string filePath = Path.Combine(@this.Directory.FullName, newName);
            @this.MoveTo(filePath);
        }

        /// <summary>
        ///     Creates all directories and subdirectories in the specified @this if the directory doesn't already exists.
        ///     This methods is the same as FileInfo.CreateDirectory however it's less ambigues about what happen if the
        ///     directory already exists.
        /// </summary>
        /// <param name="this">The directory @this to create.</param>
        /// <returns>An object that represents the directory for the specified @this.</returns>
        /// ###
        /// <exception cref="T:System.IO.IOException">
        ///     The directory specified by <paramref name="this" /> is a file.-or-The
        ///     network name is not known.
        /// </exception>
        /// ###
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// ###
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="this" /> is a zero-length string, contains only
        ///     white space, or contains one or more invalid characters as defined by
        ///     <see
        ///         cref="F:System.IO.Path.InvalidPathChars" />
        ///     .-or-<paramref name="this" /> is prefixed with, or contains only a colon character (:).
        /// </exception>
        /// ###
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="this" /> is null.
        /// </exception>
        /// ###
        /// <exception cref="T:System.IO.PathTooLongException">
        ///     The specified @this, file name, or both exceed the system-
        ///     defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file
        ///     names must be less than 260 characters.
        /// </exception>
        /// ###
        /// <exception cref="T:System.IO.DirectoryNotFoundException">
        ///     The specified @this is invalid (for example, it is on
        ///     an unmapped drive).
        /// </exception>
        /// ###
        /// <exception cref="T:System.NotSupportedException">
        ///     <paramref name="this" /> contains a colon character (:) that
        ///     is not part of a drive label ("C:\").
        /// </exception>
        public static DirectoryInfo EnsureDirectoryExists(this FileInfo @this)
        {
            return Directory.CreateDirectory(@this.Directory.FullName);
        }

        #endregion

        #region Directory

        /// <summary>
        /// 过滤符合条件的<see cref="FileInfo"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static FileInfo[] FilterFiles(this DirectoryInfo @this, Predicate<FileInfo> predicate)
        {
            List<FileInfo> files = new List<FileInfo>();
            @this.GetFiles().ForEach(x =>
            {
                if (predicate(x)) files.Add(x);
            });
            return files.ToArray();
        }

        /// <summary>
        /// 过滤符合条件的<see cref="DirectoryInfo"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static DirectoryInfo[] FilterDirectories(this DirectoryInfo @this, Predicate<DirectoryInfo> predicate)
        {
            List<DirectoryInfo> files = new List<DirectoryInfo>();
            @this.GetDirectories().ForEach(x =>
            {
                if (predicate(x)) files.Add(x);
            });
            return files.ToArray();
        }

        /// <summary>
        /// 查找目录中为指定名称的文件
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static FileInfo FindFile(this DirectoryInfo @this, string name)
        {
            foreach(FileInfo file in @this.GetFiles())
            {
                if(file.Name == name)
                {
                    return file;
                }
            }
            foreach(DirectoryInfo dir in @this.GetDirectories())
            {
                return dir.FindFile(name);
            }
            return null;
        }

        #endregion
    }
}
