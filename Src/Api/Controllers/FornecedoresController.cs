using Business.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System;
using Api.Dtos;
using Business.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository, IMapper mapper, IFornecedorService fornecedorService)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<IEnumerable<Dtos.FornecedorDto>> Get()
        {
            var fornecedores = _mapper.Map<IEnumerable<Dtos.FornecedorDto>>(await _fornecedorRepository.ObterTodos());
            return fornecedores;
        }

        [HttpGet("id:guid")]
        public async Task<ActionResult<IEnumerable<Dtos.FornecedorDto>>> Get(Guid id)
        {
            var fornecedor = await GetProviderProductAdressById(id);

            if (fornecedor == null) return NotFound();

            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorDto>> Include(FornecedorDto fornecedorDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
            
            var result = await _fornecedorService.Insert(fornecedor);

            if (!result) return BadRequest();

            return Ok(fornecedor);                        
        }

        [HttpPut]
        public async Task<ActionResult<FornecedorDto>> Update(Guid id, FornecedorDto fornecedorDto)
        {
            if (id != fornecedorDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);

            var result = await _fornecedorService.Update(fornecedor);

            if (!result) return BadRequest();

            return Ok(fornecedor);
        }

        [HttpDelete("id:guid")]
        public async Task<ActionResult<FornecedorDto>> Delete(Guid id)
        {
            var fornecedor = await _fornecedorRepository.GetProviderProductAdressById (id);

            if (fornecedor == null) return NotFound();

            var result = await _fornecedorService.Delete(id);

            if (!result) return NotFound();

            return Ok(fornecedor);
        }


        public async Task<ActionResult<FornecedorDto>> GetProviderProductAdressById(Guid id)
        {
            return _mapper.Map<FornecedorDto>(await _fornecedorRepository.GetProviderProductAdressById(id));
        }

    }
}