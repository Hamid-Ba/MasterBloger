using System;
using System.ComponentModel.DataAnnotations;

namespace Framework.Helpers;

public enum CommentStatus
{
    [Display(Name = "Depending")]
    Depending,

    [Display(Name = "Confirm")]
    Confirm,

    [Display(Name = "Reject")]
    Reject
}