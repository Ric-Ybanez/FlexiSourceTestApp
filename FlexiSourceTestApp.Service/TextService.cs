using FlexiSourceTestApp.Common.Request;
using FlexiSourceTestApp.Common.Response;
using System;
using System.Collections.Generic;

namespace FlexiSourceTestApp.Service
{
    public class TextService : ITextService
    {
        public StringMatchResponse StringSearch(StringMatchRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
                throw new ArgumentNullException("Text cannot be empty");
            if (string.IsNullOrEmpty(request.SubText))
                throw new ArgumentNullException("Subtext cannot be empty");

            if (request.SubText.Length > request.Text.Length)
                throw new ArgumentNullException("Subtext cannot be longer than Text");

            string mainText = request.Text.ToLower();
            string searchText = request.SubText.ToLower();

            List<int> matchFirstIndexes = new List<int>();
            while (mainText.Contains(searchText))
            {
                var matchFirstIndex = mainText.IndexOf(searchText);
                mainText = mainText.Remove(matchFirstIndex, searchText.Length);
                matchFirstIndexes.Add(matchFirstIndex + (searchText.Length * matchFirstIndexes.Count));
            }

            return new StringMatchResponse { MatchFirstIndexes = matchFirstIndexes };
        }
    }
}
