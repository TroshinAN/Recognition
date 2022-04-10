using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntLabLibrary
{
    using DllReturnType = System.Int32;
    using DllHandleType = System.Int64;

    /// <summary>
    /// Экземпляр дескриптора объекта.
    /// </summary>
    public class DllHandle
    {
        /// <summary>
        /// Пустой дескриптор.
        /// </summary>
        public const DllHandleType HandleZero = 0;

        /// <summary>
        /// Тип библиотеки.
        /// </summary>
        public LibraryType LibraryType { get; private set; }

        /// <summary>
        /// Дескриптор.
        /// </summary>
        public DllHandleType Handle { get; private set; }

        /// <summary>
        /// Экземпляр родительского дескриптора
        /// </summary>
        public DllHandleType Parent { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="libraryType">Тип библиотеки.</param>
        /// <param name="handle">Дескриптор объекта.</param>
        /// <param name="parent">Экземпляр родительского дескриптора.</param>
        internal DllHandle(LibraryType libraryType, DllHandleType handle, DllHandle parent = null)
        {
            this.LibraryType = libraryType;
            this.Handle = handle;

            if (parent != null)
            {
                if (parent.Parent != HandleZero)
                {
                    throw new ArgumentException("Предок дескриптора должен быть одним в текущей версии.");
                }
                if (parent.LibraryType != libraryType)
                {
                    throw new ArgumentException(String.Format("Тип дескриптора {0} не совпадает с типом дескриптора родителя {1}.", libraryType.ToString(), parent.LibraryType.ToString()));
                }
            }
            this.Parent = parent == null ? HandleZero : parent.Handle;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="type">Тип библиотеки.</param>
        public DllHandle(LibraryType type) : this(type, HandleZero) { }

        /// <summary>
        /// Строковое представление экземпляра дескриптора.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(String.Format("Дескриптор устройства {0};", LibraryType.ToString()));
            builder.AppendFormat("Значение :{0}{1};", Handle, Parent != HandleZero ? String.Format(" (родитель:{0})", Parent) : "");
            return builder.ToString();
        }
    }
}
