using System;
using System.Collections.Generic;
using System.Linq;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.SERVICE
{
    public class SLASLTsService : BaseService<Conf_SLASLTs>, ISLASLTsService
    {
        private readonly ISLASLTsRepository _slaSLTsRepository;

        public SLASLTsService(ISLASLTsRepository slaSLTsRepository)
        {
            this._slaSLTsRepository = slaSLTsRepository;
        }
        public List<Conf_SLASLTs> GetList(string slaId)
        {
            return _slaSLTsRepository.GetList(slaId);
        } 
        public void SetSLTs(string slaId, params string[] sltIds)
        { 
            var listNewsltIdss = sltIds.ToList(); 
            var listOldRRs = _slaSLTsRepository.GetList(slaId); 
            for (int i = listOldRRs.Count - 1; i >= 0; i--)
            {
                if (listNewsltIdss.Contains(listOldRRs[i].SLTsId))
                {
                    listNewsltIdss.Remove(listOldRRs[i].SLTsId);
                    listOldRRs.Remove(listOldRRs[i]);
                }
            } 
            listNewsltIdss.ForEach((sltsId) =>
            {
                _slaSLTsRepository.Insert(new Conf_SLASLTs()
                {
                    SLAId = slaId,
                    SLTsId = sltsId,
                    Id = Tools.GuId(),
                    CreateUser = OperatorProvider.Instance.Current.Account,
                    CreateTime = DateTime.Now
                });
            }); 
            listOldRRs.ForEach((rrObj) =>
            {
                _slaSLTsRepository.Delete(rrObj);
            });
        }

    }
}
