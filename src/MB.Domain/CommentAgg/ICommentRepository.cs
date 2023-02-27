﻿using System;
using Framework.Domain;
using MB.Application.Contract.CommentAgg;

namespace MB.Domain.CommentAgg;

public interface ICommentRepository : IRepository<Comment>
{
    List<CommentListDto> GetList();
}