namespace Backlog.Features.Feedback
{
    public class FeedbackApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromFeedback<TModel>(Data.Model.Feedback feedback) where
            TModel : FeedbackApiModel, new()
        {
            var model = new TModel();
            model.Id = feedback.Id;
            return model;
        }

        public static FeedbackApiModel FromFeedback(Data.Model.Feedback feedback)
            => FromFeedback<FeedbackApiModel>(feedback);
    }
}