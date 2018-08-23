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
    public class PositionService : BaseService<Sys_Position>, IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository)
        {
            this._positionRepository = positionRepository;
        }

        public List<Sys_Position_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord, string parentId)
        {
            return _positionRepository.GetPageJoinList(pageIndex, pageSize, out count, keyWord, parentId).ToList();
        }

        public List<Sys_User_Dto> GetUserByPosition(int pageIndex, int pageSize, out int count, string PositionId)
        {
            return _positionRepository.GetUserByPosition(pageIndex, pageSize, out count, PositionId).ToList();
        }

        public Sys_Position_Dto GetPosition(string PositionId)
        {
            return _positionRepository.GetPosition(PositionId);
        }

        public List<Sys_Position_Dto> GetChildPositionByPositionID(string PositionId)
        {
            return _positionRepository.GetChildPositionByPositionID(PositionId).ToList();
        }

        public override object Insert(Sys_Position model)
        {
            model.Id = Tools.GuId();
            model.IsEnable = model.IsEnable == null ? false : true;
            model.CreateUser = OperatorProvider.Instance.Current.Account;
            model.CreateTime = DateTime.Now;
            return _positionRepository.Insert(model);
        }
        public override bool Update(Sys_Position model)
        {
            model.IsEnable = model.IsEnable == null ? false : true;
            return _positionRepository.Update(model);
        }
    }
}
