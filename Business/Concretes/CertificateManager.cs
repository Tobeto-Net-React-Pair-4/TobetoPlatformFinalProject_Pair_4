using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Certificate.Requests;
using Business.Dtos.Certificate.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CertificateManager : ICertificateService
    {

        private ICertificateDal _certificateDal;
        private IMapper _mapper;
        private CertificateBusinessRules _certificateBusinessRules;
        public CertificateManager(ICertificateDal certificateDal, IMapper mapper, CertificateBusinessRules certificateBusinessRules)
        {
            _certificateDal = certificateDal;
            _mapper = mapper;
            _certificateBusinessRules = certificateBusinessRules;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedCertificateResponse> AddAsync(CreateCertificateRequest createCertificateRequest)
        {
            await _certificateBusinessRules.CheckIfUserExists(createCertificateRequest.UserId);

            Certificate certificate = _mapper.Map<Certificate>(createCertificateRequest);
            certificate.Id = Guid.NewGuid();

            Certificate createdCertificate = await _certificateDal.AddAsync(certificate);

            return _mapper.Map<CreatedCertificateResponse>(createdCertificate);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedCertificateResponse> DeleteAsync(Guid certificateId)
        {
            await _certificateBusinessRules.CheckIfExistsById(certificateId);

            Certificate certificate = await _certificateDal.GetAsync(p => p.Id == certificateId);
            await _certificateDal.DeleteAsync(certificate);
            return _mapper.Map<DeletedCertificateResponse>(certificate);
        }
        public async Task<Paginate<GetListCertificateResponse>> GetListAsync()
        {
            var data = await _certificateDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCertificateResponse>>(data);
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedCertificateResponse> UpdateAsync(UpdateCertificateRequest updateCertificateRequest)
        {
            await _certificateBusinessRules.CheckIfExistsById(updateCertificateRequest.Id);
            await _certificateBusinessRules.CheckIfUserExists(updateCertificateRequest.UserId);

            Certificate certificate = await _certificateDal.GetAsync(p => p.Id == updateCertificateRequest.Id);
            _mapper.Map(updateCertificateRequest, certificate);
            await _certificateDal.UpdateAsync(certificate);
            return _mapper.Map<UpdatedCertificateResponse>(certificate);
        }
    }
}
