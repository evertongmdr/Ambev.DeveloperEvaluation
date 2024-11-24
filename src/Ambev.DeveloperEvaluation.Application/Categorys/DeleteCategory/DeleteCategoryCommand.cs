﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Categorys.DeleteCategory
{
    /// <summary>
    /// Represents the command to delete a category.
    /// </summary>
    public class DeleteCategoryCommand : IRequest<DeleteCategoryResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the category to be deleted.
        /// </summary>
        public Guid Id { get; set; }

        public DeleteCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
