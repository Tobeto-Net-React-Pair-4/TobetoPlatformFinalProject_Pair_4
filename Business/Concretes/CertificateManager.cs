using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Certificate.Requests;
using Business.Dtos.Certificate.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CertificateManager : ICertificateService
    {

        private ICertificateDal _certificateDal;
        private IMapper _mapper;
        public CertificateManager(ICertificateDal certificateDal, IMapper mapper)
        {
            _certificateDal = certificateDal;
            _mapper = mapper;
        }
        public async Task<CreatedCertificateResponse> AddAsync(CreateCertificateRequest createCertificateRequest)
        {
            Certificate certificate = _mapper.Map<Certificate>(createCertificateRequest);
            certificate.Id = Guid.NewGuid();

            Certificate createdCertificate = await _certificateDal.AddAsync(certificate);

            return _mapper.Map<CreatedCertificateResponse>(createdCertificate);
        }

        public async Task<DeletedCertificateResponse> DeleteAsync(DeleteCertificateRequest deleteCertificateRequest)
        {
            Certificate certificate = await _certificateDal.GetAsync(p => p.Id == deleteCertificateRequest.Id);
            await _certificateDal.DeleteAsync(certificate);
            return _mapper.Map<DeletedCertificateResponse>(certificate);
        }


        public async Task<Paginate<GetListCertificateResponse>> GetListAsync()
        {
            var data = await _certificateDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCertificateResponse>>(data);
        }

        public async Task<UpdatedCertificateResponse> UpdateAsync(UpdateCertificateRequest updateCertificateRequest)
        {
            Certificate certificate = await _certificateDal.GetAsync(p => p.Id == updateCertificateRequest.Id);
            _mapper.Map(updateCertificateRequest, certificate);
            await _certificateDal.UpdateAsync(certificate);
            return _mapper.Map<UpdatedCertificateResponse>(certificate);
        }
    }
}
