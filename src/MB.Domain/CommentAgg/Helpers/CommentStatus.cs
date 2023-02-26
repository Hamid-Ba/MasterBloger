using System;
using System.ComponentModel.DataAnnotations;

namespace MB.Domain.CommentAgg.Helpers
{
	public enum CommentStatus
	{
		[Display(Name = "Depending")]
		Depending,

        [Display(Name = "Confirm")]
        Confirm,

        [Display(Name = "Reject")]
        Reject
	}
}