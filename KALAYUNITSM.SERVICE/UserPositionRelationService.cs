using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.SERVICE
{
    public class UserPositionRelationService : BaseService<Sys_UserPositionRelation>, IUserPositionRelationService
    {
        private readonly IUserPositionRelationRepository _userPositionRelationRepository;

        public UserPositionRelationService(IUserPositionRelationRepository userPositionRelationRepository)
        {
            this._userPositionRelationRepository = userPositionRelationRepository;
        }
        public List<Sys_UserPositionRelation> GetList(string userId)
        {
            return _userPositionRelationRepository.GetList(userId);
        }

        public void SetPosition(string userId, string positionId)
        {
            var listOldRRs = _userPositionRelationRepository.GetList(userId);
            if (listOldRRs.Count != 0) //不是新建
                _userPositionRelationRepository.Delete(listOldRRs[0]);//清除过去！

            _userPositionRelationRepository.Insert(new Sys_UserPositionRelation()
            {
                UserId = userId,
                PositionId  = positionId,
                Id = Tools.GuId(),
                CreateUser = OperatorProvider.Instance.Current.Account,
                CreateTime = DateTime.Now
            });

        }

    }
}
