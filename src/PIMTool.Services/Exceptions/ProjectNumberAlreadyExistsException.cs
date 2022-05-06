using System;

namespace PIMTool.Services.Exceptions
{
    [Serializable]
    public class ProjectNumberAlreadyExistsException : Exception
    {
        public ProjectNumberAlreadyExistsException()
        {

        }

        public ProjectNumberAlreadyExistsException(int message) : base(string.Format("Project number {0} is existed in System", message))
        {

        }

        public ProjectNumberAlreadyExistsException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
