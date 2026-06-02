using BackendApp.Data;
using BackendApp.Dto.SearchFilterDto;
using BackendApp.Models;
using BackendApp.Repositories.AbstractBase;
using BackendApp.Repositories.ExtensionBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Repositories
{
    public class F031_ErmosRepository : AbstractBaseRepository<f031_ermo>, ISearchData<f031_ermo>
    {
        private readonly ApplicationDbContext _context;

        public F031_ErmosRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f031_ermo> GetEnitityByAttributes(f031_ermo f031_ermoData)
        {
            IQueryable<f031_ermo> f031_ermoResult = _context.F031_Ermos;

            f031_ermo updatedF031_Ermo = null;
            if (!f031_ermoData.Id.IsNullOrEmpty())
            {
                f031_ermoResult = f031_ermoResult
                    .Where(c => c.Id == f031_ermoData.Id);

                f031_ermo existingF031_Ermo = await f031_ermoResult.FirstOrDefaultAsync();
                if (existingF031_Ermo != null)
                {
                    updatedF031_Ermo = await UpdateObject(existingF031_Ermo, f031_ermoData);
                }
            }

            //if (f031_ermoData.OrganizationId != null && f031_ermoData.OrganizationId != 0)
            //{
            //    f031_ermoResult = f031_ermoResult
            //        .Where(c => c.OrganizationId == f031_ermoData.OrganizationId);
            //}

            //if (f031_ermoData.OrgDocumentId != null && f031_ermoData.OrgDocumentId != 0)
            //{
            //    f031_ermoResult = f031_ermoResult
            //        .Where(c => c.OrgDocumentId == f031_ermoData.OrgDocumentId);
            //}

            //if (f031_ermoData.AddressId != null && f031_ermoData.AddressId != 0)
            //{
            //    f031_ermoResult = f031_ermoResult
            //        .Where(c => c.AddressId == f031_ermoData.AddressId);
            //}

            //if (f031_ermoData.BaseDataId != null && f031_ermoData.BaseDataId != 0)
            //{
            //    f031_ermoResult = f031_ermoResult
            //        .Where(c => c.BaseDataId == f031_ermoData.BaseDataId);
            //}

            return updatedF031_Ermo;
        }

        public async Task<f031_ermo> UpdateObject(f031_ermo existingEntity, f031_ermo entityData)
        {
            if (entityData.OrganizationId != null
                && entityData.OrganizationId != 0
                && entityData.OrganizationId != existingEntity.OrganizationId)
            {
                existingEntity.OrganizationId = entityData.OrganizationId;
            }

            if (entityData.OrgDocumentId != null
                && entityData.OrgDocumentId != 0
                && entityData.OrgDocumentId != existingEntity.OrgDocumentId)
            {
                existingEntity.OrgDocumentId = entityData.OrgDocumentId;
            }

            if (entityData.AddressId != null
                && entityData.AddressId != 0
                && entityData.AddressId != existingEntity.AddressId)
            {
                existingEntity.AddressId = entityData.AddressId;
            }

            if (entityData.BaseDataId != null
                && entityData.BaseDataId != 0
                && entityData.BaseDataId != existingEntity.BaseDataId)
            {
                existingEntity.BaseDataId = entityData.BaseDataId;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }

        // взятие данных по поиску
        public async Task<List<object>> GetDataBySearchFilter(Dictionary<string, object> filter)
        {
            IQueryable<f031_ermo> f031_ermo = _context.F031_Ermos;

            DateTime? dateBeg = null;

            if (filter != null)
            {
                if (filter.ContainsKey("DateBeg") && !filter["DateBeg"].ToString().IsNullOrEmpty())
                {
                    dateBeg = DateTime.ParseExact(filter["DateBeg"].ToString(), "dd-MM-yyyy", null);
                }

                DateTime? dateEnd = null;
                if (filter.ContainsKey("DateEnd") && !filter["DateEnd"].ToString().IsNullOrEmpty())
                {
                    dateBeg = DateTime.ParseExact(filter["DateEnd"].ToString(), "dd-MM-yyyy", null);
                }

                if (dateBeg != null && dateEnd != null)
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.DateBeg >= dateBeg
                            && c.DateEnd <= dateEnd
                        );
                }
                else
                {
                    if (dateBeg != null)
                    {
                        f031_ermo = f031_ermo
                            .Where(c =>
                               c.DateBeg == dateBeg
                            );
                    }

                    if (dateEnd != null)
                    {
                        f031_ermo = f031_ermo
                            .Where(c =>
                               c.DateEnd == dateEnd
                            );
                    }
                }

                if (filter.ContainsKey("Id") && !filter["Id"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Id.Contains(filter["Id"].ToString())
                        );
                }

                if (filter.ContainsKey("OrgName") && !filter["OrgName"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Organization.OrgName.Name.Contains(filter["OrgName"].ToString())
                        );
                }

                if (filter.ContainsKey("OrgShortName") && !filter["OrgShortName"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Organization.OrgName.ShortName.Contains(filter["OrgShortName"].ToString())
                        );
                }

                if (filter.ContainsKey("Inn") && !filter["Inn"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Document.Inn.Contains(filter["Inn"].ToString())
                        );
                }

                if (filter.ContainsKey("Kpp") && !filter["Kpp"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Document.Kpp.Contains(filter["Kpp"].ToString())
                        );
                }

                if (filter.ContainsKey("Ogrn") && !filter["Ogrn"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Document.Ogrn.Contains(filter["Ogrn"].ToString())
                        );
                }

                if (filter.ContainsKey("OidMo") && !filter["OidMo"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.OrgDocument.OidTypeMo.Name.Contains(filter["OidMo"].ToString())
                        );
                }

                if (filter.ContainsKey("Okopf") && !filter["Okopf"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Organization.Okopf.Contains(filter["Okopf"].ToString())
                        );
                }

                if (filter.ContainsKey("Okfs") && !filter["Okfs"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.OrgDocument.Okfs.Contains(filter["Okfs"].ToString())
                        );
                }

                if (filter.ContainsKey("AddrName") && !filter["AddrName"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Address.Name.Contains(filter["AddrName"].ToString())
                        );
                }

                if (filter.ContainsKey("AddrCode") && !filter["AddrCode"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Address.AddressCode.Contains(filter["AddrCode"].ToString())
                        );
                }

                if (filter.ContainsKey("Oktmo") && !filter["Oktmo"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Address.Oktmo.Contains(filter["Oktmo"].ToString())
                        );
                }

                if (filter.ContainsKey("Email") && !filter["Email"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Communication.Email.Contains(filter["Email"].ToString())
                        );
                }

                if (filter.ContainsKey("Phone") && !filter["Phone"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Communication.Phone.Contains(filter["Phone"].ToString())
                        );
                }

                if (filter.ContainsKey("Phone") && !filter["Phone"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Communication.Phone.Contains(filter["Phone"].ToString())
                        );
                }

                if (filter.ContainsKey("Fax") && !filter["Fax"].ToString().IsNullOrEmpty())
                {
                    f031_ermo = f031_ermo
                        .Where(c =>
                            c.Communication.Fax.Contains(filter["Fax"].ToString())
                        );
                }
            }

            return await f031_ermo
                .Select(x =>
                            new {
                                Id = x.Id,                    // только Id
                                OrgName = x.Organization.OrgName.Name,
                                OrgShortName = x.Organization.OrgName.ShortName,
                                Inn = x.Document.Inn,
                                Kpp = x.Document.Kpp,
                                Ogrn = x.Document.Ogrn,
                                OidMo = x.OrgDocument.OidTypeMo.Name,
                                Okopf = x.Organization.Okopf,
                                Okfs = x.OrgDocument.Okfs,
                                AddrName = x.Address.Name,
                                AddrCode = x.Address.AddressCode,
                                Oktmo = x.Address.Oktmo,
                                Email = x.Communication.Email,
                                Phone = x.Communication.Phone,
                                Fax = x.Communication.Fax,
                                DateBeg = x.DateBeg,
                                DateEnd = x.DateEnd
                            }
                        )
                .Cast<object>()
                .ToListAsync();
        }
    }
}
