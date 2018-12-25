using AutoMapper;
using Common;
using Common.CustomExceptions;
using Contracts.DTO;
using Models;
using Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICommentService
    {
        Task<CommentDTO> AddComment(CommentDTO dto, RemoteInfo remote);
        Task<List<CommentDTO>> GetCommentByPostId(string postid);
        Task<CommentDTO> LikeComment(string id);
    }
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentDTO> AddComment(CommentDTO dto, RemoteInfo remote)
        {
            var comment = Mapper.Map<CommentDTO, Comment>(dto);
            comment.Remote = remote;
            await _commentRepository.Add(comment);
            return dto;
        }

        public async Task<List<CommentDTO>> GetCommentByPostId(string postid)
        {
            var comments = await _commentRepository.GetCommentByPostId(postid);
            var dtos = Mapper.Map<List<Comment>, List<CommentDTO>>(comments);
            return dtos;
        }

        public async Task<CommentDTO> LikeComment(string id)
        {
            var exit = await  _commentRepository.Get(id);
            if (exit != null)
            {
                var comment = await _commentRepository.AddCommentLike(id);
                var dto = Mapper.Map<Comment, CommentDTO>(comment);
                return dto;
            }
            else {
                throw new BusinessException(ResultCode.BADREQUEST,"评论不存在");
            }

        }

    }
}
