﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;

namespace Business.Dtos.Exam.Responses
{
    public class CreatedExamResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Time { get; set; }
        public int QuestionQuantity { get; set; }
        public string ExamType { get; set; }
        public bool IsCompleted { get; set; }
        public int Score { get; set; }
        public int TrueAnswerCount { get; set; }
        public int FalseAnswerCount { get; set; }
        public int EmptyAnswerCount { get; set; }
        public DateTime ExamStartDate { get; set; }
        public DateTime ExamEndDate { get; set; }
    }
}
