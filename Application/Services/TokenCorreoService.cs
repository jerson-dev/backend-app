using Application.Interfaces;
using Application.Interfaces.Utilities;
using Application.Requests;
using Application.Utilities;
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Utilities.Exceptions.Exceptions;

namespace Application.Services
{
    public class TokenCorreoService : ITokenCorreoService
    {
        private readonly ITokenCorreoRepository _tokenCorreoRepository;
        private readonly IMailService _mailService;
        private readonly IFTPService _FTPService;


        public TokenCorreoService(ITokenCorreoRepository tokenCorreoRepository, IMailService mailService, IFTPService fTPService)
        {
            _tokenCorreoRepository = tokenCorreoRepository;
            _mailService = mailService;
            _FTPService = fTPService;
        }

        public async Task CreateTokenCorreoAsync(RegisterTokenCorreoRequest tokenCorreo)
        {
            ValidateRequest(tokenCorreo);
            string mailNoSpaces = tokenCorreo.Email!.Replace(" ", "");

            var passTCNohash = GenerateUniqueToken();
            if (IsExistEmail(mailNoSpaces))
            {
                var existingTokenCorreo = _tokenCorreoRepository.GetByEmail(mailNoSpaces);
                existingTokenCorreo.Token = HashUtils.GetHashFirst(passTCNohash);
                existingTokenCorreo.FechaCreacion = DateTime.UtcNow;
                existingTokenCorreo.ContadorDePeticiones = existingTokenCorreo.ContadorDePeticiones + 1;
                _tokenCorreoRepository.UpdateToken(existingTokenCorreo);
            }
            else
            {
                var newTokenCorreo = NewTaakTokenCorreo(tokenCorreo, passTCNohash);
                _tokenCorreoRepository.CreateTokenCorreo(newTokenCorreo);
            }

            string titileMsn = "¡Bienvenido a Taak!";
            await SendTokenMailAsync(tokenCorreo, passTCNohash, titileMsn).ConfigureAwait(false);
        }

        private string GenerateUniqueToken()
        {
            string passNoHash;
            string passHashed;
            TaakTokenCorreo existingToken;

            do
            {
                passNoHash = HashUtils.GenerateRandomToken(6).ToUpper();

                passHashed = HashUtils.GetHashFirst(passNoHash);

                //Validar por fecha
                existingToken = _tokenCorreoRepository.GetAll().FirstOrDefault(x => x.Token == passHashed);

            } while (existingToken != null);

            return passNoHash;
        }

        private TaakTokenCorreo NewTaakTokenCorreo(RegisterTokenCorreoRequest tokenCorreo, string passTCNohash)
        {
            var newTokenCorreo = new TaakTokenCorreo
            {
                Email = tokenCorreo.Email!.Replace(" ", ""),
                Token = HashUtils.GetHashFirst(passTCNohash),
                FechaCreacion = DateTime.UtcNow, // flag tipo de dato
                ContadorDePeticiones = 0,
                Estado = true
            };
            return newTokenCorreo;
        }

        private void ValidateRequest(RegisterTokenCorreoRequest tokenCorreo)
        {
            if (string.IsNullOrWhiteSpace(tokenCorreo.Email)) 
            {
                throw new ValidationException(MessagesExceptions.FieldsRequired);
            }
              
        }

        public bool IsExistEmail(string email)
        {
            return  _tokenCorreoRepository.GetAll().Exists(x => x.Email == email);
        }

        public bool IsExistToken(string email, string token)
        {
            email = email.Replace(" ", "");
            token = token.Replace(" ", "");

            var tokenDes = HashUtils.GetHashFirst(token);
            var tokenCorreo = _tokenCorreoRepository.GetByEmail(email);

            if (tokenCorreo == null)
            {
                return false;
            }

            if (tokenCorreo.Token != tokenDes)// dejarlo dentro de linea 91
            {
                return false;
            }

            TimeSpan elapsed = DateTime.UtcNow - tokenCorreo.FechaCreacion;

            if (elapsed.TotalMinutes > 10)
            {
                tokenCorreo.Estado = false;
                _tokenCorreoRepository.UpdateToken(tokenCorreo);

                return false; 
            }

            return true;
        }

        public async Task SendTokenMailAsync(RegisterTokenCorreoRequest register, string passTCNohash, string titleMsn)
        {
            TaakTokenCorreo tokenCorreo = new TaakTokenCorreo();
            tokenCorreo.Email = register.Email!;
            tokenCorreo.Token = passTCNohash;

            String filename = "ConfirmEmail.html";
            String htmlContent = MailService.ReplaceWithObjectProperties(
                template: await _mailService.getHtmlFileAsync(filename).ConfigureAwait(false),
                obj: tokenCorreo
                );
            _mailService.SendEmailGmail(register.Email!, titleMsn, htmlContent);
        }
    }
}
