using BackendApp.Data;
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
    public class F032_TrmoRepository : AbstractBaseRepository<f032_trmo>, ISearchData<f032_trmo>
    {
        private readonly ApplicationDbContext _context;

        public F032_TrmoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<f032_trmo> GetEnitityByAttributes(f032_trmo entityData)
        {
            IQueryable<f032_trmo> f032_TrmosResult = _context.F032_Trmos;

            if (!entityData.Id.IsNullOrEmpty()) {
                f032_TrmosResult = f032_TrmosResult
                    .Where(c => c.Id == entityData.Id);
            }

            //if (entityData.OrganizationId != null && entityData.OrganizationId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.OrganizationId == entityData.OrganizationId);
            //}

            //if (entityData.AddressId != null && entityData.AddressId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.AddressId == entityData.AddressId);
            //}

            //if (entityData.DocumentId != null && entityData.DocumentId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.DocumentId == entityData.DocumentId);
            //}

            //if (entityData.OspTypeId != null && entityData.OspTypeId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.OspTypeId == entityData.OspTypeId);
            //}

            //if (entityData.ExclusionDate != default(DateTime) && entityData.ExclusionDate != null)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.ExclusionDate == entityData.ExclusionDate);
            //}

            //if (entityData.InclusionDate != default(DateTime) && entityData.InclusionDate != null)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.InclusionDate == entityData.InclusionDate);
            //}

            //if (entityData.OrgDocumentId != null && entityData.OrgDocumentId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.OrgDocumentId == entityData.OrgDocumentId);
            //}

            //if (entityData.DateBeg != default(DateTime))
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.DateBeg == entityData.DateBeg);
            //}

            //if (entityData.DateEnd != default(DateTime) && entityData.DateEnd != null)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.DateEnd == entityData.DateEnd);
            //}

            //if (entityData.CommunicationId != null && entityData.CommunicationId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.CommunicationId == entityData.CommunicationId);
            //}

            //if (entityData.BaseDataId != null && entityData.BaseDataId != 0)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.BaseDataId == entityData.BaseDataId);
            //}

            //if (!entityData.ParentId.IsNullOrEmpty())
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.ParentId == entityData.ParentId);
            //}

            //if (!entityData.f031_ermoId.IsNullOrEmpty())
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.f031_ermoId == entityData.f031_ermoId);
            //}

            //if (entityData.f031_ermoParentId != null)
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.f031_ermoParentId == entityData.f031_ermoParentId);
            //}

            //if (entityData.DateBeginOms != null && entityData.DateBeginOms != default(DateTime))
            //{
            //    f032_TrmosResult = f032_TrmosResult
            //        .Where(c => c.DateBeginOms == entityData.DateBeginOms);
            //}

            return await f032_TrmosResult.FirstOrDefaultAsync();
        }

        public async Task<f032_trmo> UpdateObject(f032_trmo existingEntity, f032_trmo entityData)
        {
            if (entityData.OrganizationId != null
                && entityData.OrganizationId != 0
                && entityData.OrganizationId != existingEntity.OrganizationId)
            {
                existingEntity.OrganizationId = entityData.OrganizationId;
            }

            if (entityData.AddressId != null
                && entityData.AddressId != 0
                && entityData.AddressId != existingEntity.AddressId)
            {
                existingEntity.AddressId = entityData.AddressId;
            }

            if (entityData.DocumentId != null
                && entityData.DocumentId != 0
                && entityData.DocumentId != existingEntity.DocumentId)
            {
                existingEntity.DocumentId = entityData.DocumentId;
            }

            if (entityData.OspTypeId != null
                && entityData.OspTypeId != 0
                && entityData.OspTypeId != existingEntity.OspTypeId)
            {
                existingEntity.OspTypeId = entityData.OspTypeId;
            }

            if (entityData.ExclusionDate != default(DateTime)
                && entityData.ExclusionDate != null
                && entityData.ExclusionDate != existingEntity.ExclusionDate)
            {
                existingEntity.ExclusionDate = entityData.ExclusionDate;
            }

            if (entityData.InclusionDate != default(DateTime)
                && entityData.InclusionDate != null
                && entityData.InclusionDate != existingEntity.InclusionDate)
            {
                existingEntity.ExclusionDate = entityData.InclusionDate;
            }

            if (entityData.OrgDocumentId != null
                && entityData.OrgDocumentId != 0
                && entityData.OrgDocumentId != existingEntity.OrgDocumentId)
            {
                existingEntity.OrgDocumentId = entityData.OrgDocumentId;
            }

            if (entityData.DateBeg != default(DateTime)
                && entityData.DateBeg != existingEntity.DateBeg)
            {
                existingEntity.DateBeg = entityData.DateBeg;
            }

            if (entityData.DateEnd != default(DateTime)
                && entityData.DateEnd != null
                && entityData.DateEnd != existingEntity.DateEnd)
            {
                existingEntity.DateEnd = entityData.DateEnd;
            }

            if (entityData.CommunicationId != null
                && entityData.CommunicationId != 0
                && entityData.CommunicationId != existingEntity.CommunicationId)
            {
                existingEntity.CommunicationId = entityData.CommunicationId;
            }

            if (entityData.BaseDataId != null
                && entityData.BaseDataId != 0
                && entityData.BaseDataId != existingEntity.BaseDataId)
            {
                existingEntity.BaseDataId = entityData.BaseDataId;
            }

            if (!entityData.ParentId.IsNullOrEmpty()
                && entityData.ParentId != existingEntity.ParentId)
            {
                existingEntity.ParentId = entityData.ParentId;
            }

            if (!entityData.f031_ermoId.IsNullOrEmpty()
                && entityData.f031_ermoId != existingEntity.f031_ermoId)
            {
                existingEntity.f031_ermoId = entityData.f031_ermoId;
            }

            if (entityData.f031_ermoParentId != null
                && entityData.f031_ermoParentId != existingEntity.f031_ermoParentId)
            {
                existingEntity.f031_ermoParentId = entityData.f031_ermoParentId;
            }

            if (entityData.DateBeginOms != null
                && entityData.DateBeginOms != default(DateTime)
                && entityData.DateBeginOms != existingEntity.DateBeginOms)
            {
                existingEntity.DateBeginOms = entityData.DateBeginOms;
            }

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }

        public async Task<List<object>> GetDataBySearchFilter(Dictionary<string, object> filter)
        {
            IQueryable<f032_trmo> f032_trmo = _context.F032_Trmos;

            if (filter != null)
            {
                DateTime? dateBeg = null;
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
                    f032_trmo = f032_trmo
                        .Where(c =>
                            c.DateBeg >= dateBeg
                            && c.DateEnd <= dateEnd
                        );
                }
                else
                {
                    if (dateBeg != null)
                    {
                        f032_trmo = f032_trmo
                            .Where(c =>
                               c.DateBeg == dateBeg
                            );
                    }

                    if (dateEnd != null)
                    {
                        f032_trmo = f032_trmo
                            .Where(c =>
                               c.DateEnd == dateEnd
                            );
                    }
                }

                if (filter.ContainsKey("UidMo") && !filter["UidMo"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Id.Contains(filter["UidMo"].ToString())
                            );
                }


                if (filter.ContainsKey("IdMo") && !filter["IdMo"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.f031_ermoId.Contains(filter["IdMo"].ToString())
                            );
                }

                if (filter.ContainsKey("MCod") && !filter["MCod"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Organization.Mcod.Contains(filter["MCod"].ToString())
                            );
                }

                if (filter.ContainsKey("OktmoP") && !filter["OktmoP"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Address.Oktmo.Contains(filter["OktmoP"].ToString())
                            );
                }

                if (filter.ContainsKey("Subj") && !filter["Subj"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Address.District.Subject.Name.Contains(filter["Subj"].ToString())
                            );
                }

                if (filter.ContainsKey("InclusionDate") && !filter["InclusionDate"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.InclusionDate.ToString().Contains(filter["InclusionDate"].ToString())
                            );
                }

                if (filter.ContainsKey("DateBeginOms") && !filter["DateBeginOms"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.DateBeginOms.ToString().Contains(filter["DateBeginOms"].ToString())
                            );
                }

                if (filter.ContainsKey("DEnd") && !filter["DEnd"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.ExclusionDate.ToString().Contains(filter["DEnd"].ToString())
                            );
                }

                if (filter.ContainsKey("NameE") && !filter["NameE"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.F002_InsInclude.NameE.Contains(filter["NameE"].ToString())
                            );
                }

                if (filter.ContainsKey("Osp") && !filter["Osp"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.OspType.Name.ToString().Contains(filter["Osp"].ToString())
                            );
                }

                if (filter.ContainsKey("ParentIdMo") && !filter["ParentIdMo"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.ParentIdMo.Id.Contains(filter["ParentIdMo"].ToString())
                            );
                }

                if (filter.ContainsKey("ParentUidMo") && !filter["ParentUidMo"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.ParentId.Contains(filter["ParentUidMo"].ToString())
                            );
                }

                if (filter.ContainsKey("VidMo") && !filter["VidMo"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.OrgDocument.VidTypes.Name.Contains(filter["VidMo"].ToString())
                            );
                }

                if (filter.ContainsKey("OidMo") && !filter["OidMo"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.OrgDocument.OidTypeMo.Name.Contains(filter["OidMo"].ToString())
                            );
                }

                if (filter.ContainsKey("OidSpmo") && !filter["OidSpmo"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.OrgDocument.OidTypeSpmo.Name.Contains(filter["OidSpmo"].ToString())
                            );
                }

                if (filter.ContainsKey("OrgName") && !filter["OrgName"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Organization.OrgName.Name.Contains(filter["OrgName"].ToString())
                            );
                }

                if (filter.ContainsKey("OrgShortName") && !filter["OrgShortName"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Organization.OrgName.ShortName.Contains(filter["OrgShortName"].ToString())
                            );
                }

                if (filter.ContainsKey("Inn") && !filter["Inn"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Document.Inn.Contains(filter["Inn"].ToString())
                            );
                }

                if (filter.ContainsKey("Ogrn") && !filter["Ogrn"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Document.Ogrn.Contains(filter["Ogrn"].ToString())
                            );
                }

                if (filter.ContainsKey("Kpp") && !filter["Kpp"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Document.Kpp.Contains(filter["Kpp"].ToString())
                            );
                }

                if (filter.ContainsKey("JurAddressIndex") && !filter["JurAddressIndex"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Address.Index.Contains(filter["JurAddressIndex"].ToString())
                            );
                }

                if (filter.ContainsKey("JurAddressAddress") && !filter["JurAddressAddress"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Address.Name.Contains(filter["JurAddressAddress"].ToString())
                            );
                }

                if (filter.ContainsKey("GarAddress") && !filter["GarAddress"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Address.AddressCode.Contains(filter["GarAddress"].ToString())
                            );
                }

                if (filter.ContainsKey("GarAddress") && !filter["GarAddress"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Address.AddressCode.Contains(filter["GarAddress"].ToString())
                            );
                }

                if (filter.ContainsKey("Okfs") && !filter["Okfs"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.OrgDocument.Okfs.Contains(filter["Okfs"].ToString())
                            );
                }

                if (filter.ContainsKey("VedPri") && !filter["VedPri"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Organization.VedPri.Contains(filter["VedPri"].ToString())
                            );
                }

                if (filter.ContainsKey("Phone") && !filter["Phone"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Communication.Phone.Contains(filter["Phone"].ToString())
                            );
                }

                if (filter.ContainsKey("Fax") && !filter["Fax"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Communication.Fax.Contains(filter["Fax"].ToString())
                            );
                }

                if (filter.ContainsKey("Email") && !filter["Email"].ToString().IsNullOrEmpty())
                {
                    f032_trmo = f032_trmo
                            .Where(c =>
                               c.Communication.Email.Contains(filter["Email"].ToString())
                            );
                }
            }

            return await f032_trmo.Select(x =>
                            new {
                                UidMo = x.Id, // только Id
                                IdMo = x.f031_ermoId,
                                MCod = x.Organization.Mcod,
                                OktmoP = x.Address.Oktmo,
                                Subj = x.Address.District.Subject.Name,
                                InclusionDate = x.InclusionDate,
                                DateBeginOms = x.DateBeginOms,
                                DEnd = x.ExclusionDate,
                                //NameE
                                NameE = x.F002_InsInclude.NameE,

                                Osp = x.OspType.Name,
                                ParentIdMo = x.ParentIdMo.Id,
                                ParentUidMo = x.ParentId,
                                VidMo = x.OrgDocument.VidTypes.Name,
                                OidMo = x.OrgDocument.OidTypeMo.Name,
                                //OidSpmo
                                OidSpmo = x.OrgDocument.OidTypeSpmo.Name,

                                OrgName = x.Organization.OrgName.Name,
                                OrgShortName = x.Organization.OrgName.ShortName,
                                Inn = x.Document.Inn,
                                Kpp = x.Document.Kpp,
                                Ogrn = x.Document.Ogrn,
                                JurAddressIndex = x.Address.Index,
                                JurAddressAddress = x.Address.Name,
                                GarAddress = x.Address.AddressCode,
                                Okfs = x.OrgDocument.Okfs,
                                VedPri = x.Organization.VedPri,
                                Phone = x.Communication.Phone,
                                Fax = x.Communication.Fax,
                                Email = x.Communication.Email,
                                DateBeg = x.DateBeg,
                                DateEnd = x.DateEnd
                            }
                        )
                .Cast<object>()
                .ToListAsync(); ; // ИЗМЕНИТЬ НА ВЫВОД КОНКРЕТНЫХ ПОЛЕЙ!
        }
    }
}
