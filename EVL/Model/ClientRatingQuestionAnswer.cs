﻿namespace EVL.Model
{
    public class ClientRatingQuestionAnswer
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string QuestionDescription { get; set; }
        public string QuestionPurposeName { get; set; }
        public double QuestionWeight { get; set; }

        public double Answer { get; set; }
    }
}
