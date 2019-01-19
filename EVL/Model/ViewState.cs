﻿using EVL.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EVL.Model
{
    public class ViewState : IReadOnlyViewState
    {
        private readonly ObservableCollection<Project> projects;
        private readonly ObservableCollection<QuestionUI> questions;

        ReadOnlyObservableCollection<Project> IReadOnlyViewState.Projects => projects.AsReadOnly();
        ReadOnlyObservableCollection<QuestionUI> IReadOnlyViewState.Questions => questions.AsReadOnly();

        public string[] QuestionPurposeNames { get; }

        private ViewState(DataBaseContext context)
        {
            this.projects = new ObservableCollection<Project>(context.Projects);
            this.questions = new ObservableCollection<QuestionUI>();
            this.QuestionPurposeNames = Model.QuestionPurposeNames.All;
        }

        public static ViewState RetrieveDataFrom(DataBaseContext context)
            => new ViewState(context);

        public void AddProject(Project p)
        {
            projects.Add(p);
        }

        public void AddQuestion(QuestionUI q)
        {
            questions.Add(q);
        }

        public void DeleteProject(Project p)
        {
            projects.Remove(p);
        }


        //TODO: move or remove
        public int[] GetClientsIndex()
        {
            return questions
                .Where(q => q.QuestionPurposeName == Model.QuestionPurposeNames.ClientRating)
                .Select(questions.IndexOf)
                .ToArray();
        }
    }
}
