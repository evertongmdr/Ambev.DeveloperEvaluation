namespace Ambev.DeveloperEvaluation.WebApi.Features.Categorys.CreateCategory
{
    public class CreateCategoryResponse
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Get The Code for the Category
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Get name of the Category
        /// </summary>
        public string Name { get; set; }
    }
}
