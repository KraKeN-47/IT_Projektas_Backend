﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.Responses.ServRegResponses;
using IT_Projektas_Backend.RequestModels.ServiRegRequestModels;
using Microsoft.EntityFrameworkCore;

namespace IT_Projektas_Backend.Services.ServiRegistrationService
{
    public class ServiRegService : IServiRegService
    {
        private readonly it_projektasContext _context;
        public ServiRegService(it_projektasContext context)
        {
            _context = context;
        }
        public async Task<List<ServicesRegistrationResponses>> BuildServicesGetRegRequest(ServiRegGetRequest req)
        {
            int fkProfiliaiid = _context.Darbuotojai.Where(x => x.FkProfiliaiid == req.Id).First().IdDarbuotojai;
            var regist = await _context.PaslaugosRezervacija.Where(x => x.FkDarbuotojaiidDarbuotojai == fkProfiliaiid).ToListAsync();
            var responses = new List<ServicesRegistrationResponses>();
            foreach (var reg in regist)
            {
                int fkPaslaugaId = _context.Paslaugos.Where(x => x.Id == reg.FkPaslaugaid).FirstOrDefault().Id;
                responses.Add(new ServicesRegistrationResponses
                {
                    Id = reg.Id,
                    Data = reg.Data,
                    LaikasNuo = reg.LaikasNuo,
                    LaikasIki = reg.LaikasIki,
                    FkPaslaugaid = fkPaslaugaId,
                    FkDarbuotojaiidDarbuotojai = reg.FkDarbuotojaiidDarbuotojai,
                    FkKlientaiidKlientai = reg.FkKlientaiidKlientai
                });
            }

            return responses;
        }

        public PaslaugosRezervacija BuildServicesAddRegRequest(ServiRegAddRequest req)
        {
            int fkDarbuotojaiidDarbuotojai = _context.Darbuotojai.Where(x => x.FkProfiliaiid == req.FkDarbuotojaiidDarbuotojai).FirstOrDefault().IdDarbuotojai;
            PaslaugosRezervacija add = new PaslaugosRezervacija
            {
                Data = req.Data,
                LaikasNuo = req.LaikasNuo,
                LaikasIki = req.LaikasIki,
                FkPaslaugaid = req.FkPaslaugaid,
                FkDarbuotojaiidDarbuotojai = fkDarbuotojaiidDarbuotojai,
                FkKlientaiidKlientai = req.FkKlientaiidKlientai
            };

            _context.PaslaugosRezervacija.Add(add);
            _context.SaveChanges();
            return add;
        }
    }
}
