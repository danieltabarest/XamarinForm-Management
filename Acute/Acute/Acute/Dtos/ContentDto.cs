using System;
using MyLearn.Models;

namespace MyLearn.Dtos
{
    public class ContentDto : Data.Base.JsonObject<Content>
    {
        public string Id
        {
            get;
            set;
        }

        public string ParentId
        {
            get;
            set;
        }

        public string CourseId
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }

        public string ContentType
        {
            get;
            set;
        }

        public string FileSize
        {
            get;
            set;
        }

        public string FileType
        {
            get;
            set;
        }

        public override Content ToDomainModel()
        {
            if (ContentType == "Folder")
                return new Folder(Id, Title, CourseId);
            
            return new File(Id, Title, CourseId, FileTypeConverter())
            {
                SizeInBytes = Convert.ToDouble(FileSize),
                Extension = FileType,
                Filename = FileName,
                Body = Body,
                Url = Url
            };
        }

        private Models.FileType FileTypeConverter()
        {
			Models.FileType type;

			try
			{
				type = (Models.FileType)Enum.Parse(typeof(FileType), ContentType);
			}
			catch (Exception)
			{
                type = Models.FileType.Other;
			}

            return type;
        }
    }
}
