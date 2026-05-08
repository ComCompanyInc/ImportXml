using BackendApp.Dto;
using BackendApp.Dto.f008_TipOms;
using BackendApp.Dto.f010_subecti;
using BackendApp.Models;
using BackendApp.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Services
{
    public class F010_SubectiService
    {
        public f010_SubectiRepository _f010_SubectiRepository;

        public BaseDataService _baseDataService;
        public SubjectService _subjectService;
        public DistrictService _districtService;
        public AddressService _addressService;
        
        public F010_SubectiService(
            f010_SubectiRepository f010_SubectiRepository,
            BaseDataService baseDataService,
            SubjectService subjectService,
            DistrictService districtService,
            AddressService addressService)
        {
            _f010_SubectiRepository = f010_SubectiRepository;
            _baseDataService = baseDataService;
            _subjectService = subjectService;
            _addressService = addressService;
        }

        public async Task<bool> SaveDataFromF10(DocumentDto<F10DataDto> dataContainer)
        {
            BaseData baseData = new BaseData
            {
                Type = dataContainer.BaseData.Type,
                Version = dataContainer.BaseData.Version,
                Date = DateTime.ParseExact(dataContainer.BaseData.Date, "dd.MM.yyyy", null),
            };

            long baseDataId;

            BaseData existingBaseData = await _baseDataService.GetEnitityByAttributes(baseData);
            if (existingBaseData != null)
            {
                baseDataId = existingBaseData.Id;
            }
            else
            {
                baseDataId = (await _baseDataService.SaveBaseDataObject(baseData)).Id;
            }

            foreach (F10DataDto item in dataContainer.ZapList)
            {
                Subject subject = new Subject
                {
                    Name = item.SubjectName,
                    Okato = item.Okato
                };

                long subjectId;

                Console.WriteLine("SubjName => " + subject.Name);

                Subject existingSubject = await _subjectService.GetEnitityByAttributes(subject);
                if (existingSubject != null)
                {
                    subjectId = existingSubject.Id;
                }
                else
                {
                    subjectId = (await _subjectService.SaveSubjectObject(subject)).Id;
                }

                f010_Subecti f010_Subecti = new f010_Subecti
                {
                    BaseDataId = baseDataId,
                    SubjectId = subjectId,
                    DateBeg = DateTime.ParseExact(item.DateBeg, "dd.MM.yyyy", null),
                    DateEnd = item.DateEnd.IsNullOrEmpty()
                                ? null
                                : DateTime.ParseExact(item.DateEnd, "dd.MM.yyyy", null),
                    CodeTf = item.CodeTf,
                    Subject = subject
                };

                long f010_SubectiId;

                f010_Subecti existingF010_Subecti = await this.GetEnitityByAttributes(f010_Subecti);
                if (existingF010_Subecti != null)
                {
                    f010_SubectiId = existingF010_Subecti.Id;
                }
                else
                {
                    f010_SubectiId = (await this.SaveF010_SubectiObject(f010_Subecti)).Id;
                }
            }

            return true;
        }

        public async Task<f010_Subecti> SaveF010_SubectiObject(f010_Subecti entityData)
        {
            return await _f010_SubectiRepository.SaveData(entityData);
        }

        public async Task<f010_Subecti> GetEnitityByAttributes(f010_Subecti entityData)
        {
            return await _f010_SubectiRepository.GetEnitityByAttributes(entityData);
        }
    }
}
