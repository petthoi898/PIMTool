using System;

namespace PIMTool.Services.Exceptions
{
    public class ProjectNumberIsNotExisted : Exception
    {
        public ProjectNumberIsNotExisted()
        {

        }

        public ProjectNumberIsNotExisted(int message) : base(string.Format("Project number {0} is not existed or deleted before", message))
        {

        }

        public ProjectNumberIsNotExisted(string message, Exception inner) : base(message, inner)
        {

        }
    }
}