﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Learning_APP.Application.DTO
{
    public class ActivityDto
    {
        public Guid ActivityId { get; set; }

        /// <summary>
        /// dto
        /// </summary>
        public string Title { get; set; }
        public string Description { get; set; }
        public string PdfUrl { get; set; }
        public DateTime DueDate { get; set; }
        public string ClassLevel { get; set; }
        public Guid TeacherId { get; set; }
        public Guid? ClassGroupId { get; set; }
    }
}
