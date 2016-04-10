using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace RestApi.Models
{
    // Patient context for the in memory data
    public class PatientInMemoryContext : IPatientContext
    {
        public PatientInMemoryContext()
        {
            this.Patients = new TestPatientSet()
            {
                new Patient
                    {
                        DateOfBirth = new DateTime(1972, 10, 27),
                        FirstName = "Millicent",
                        PatientId = 1,
                        LastName = "Hammond",
                        NhsNumber = "1111111111"
                    },
                new Patient
                    {
                        DateOfBirth = new DateTime(1987, 2, 14),
                        FirstName = "Bobby",
                        PatientId = 2,
                        LastName = "Atkins",
                        NhsNumber = "2222222222"
                    },
                new Patient
                    {
                        DateOfBirth = new DateTime(1991, 12, 4),
                        FirstName = "Xanthe",
                        PatientId = 3,
                        LastName = "Camembert",
                        NhsNumber = "3333333333"
                    }
            };
            
            this.Episodes = new TestEpisodeSet()
            {
                new Episode
                    {
                        AdmissionDate = new DateTime(2014, 11, 12),
                        Diagnosis = "Irritation of inner ear",
                        DischargeDate = new DateTime(2014, 11, 27),
                        EpisodeId = 1,
                        PatientId = 1
                    },
                new Episode
                    {
                        AdmissionDate = new DateTime(2015, 3, 20),
                        Diagnosis = "Sprained wrist",
                        DischargeDate = new DateTime(2015, 4, 2),
                        EpisodeId = 2,
                        PatientId = 1
                    },
                new Episode
                    {
                        AdmissionDate = new DateTime(2015, 11, 12),
                        Diagnosis = "Stomach cramps",
                        DischargeDate = new DateTime(2015, 11, 14),
                        EpisodeId = 3,
                        PatientId = 1
                    },
                new Episode
                    {
                        AdmissionDate = new DateTime(2015, 4, 18),
                        Diagnosis = "Laryngitis",
                        DischargeDate = new DateTime(2015, 5, 26),
                        EpisodeId = 4,
                        PatientId = 2
                    }

            };
       }

        public IDbSet<Patient> Patients { get; private set; }
        public IDbSet<Episode> Episodes { get; private set; }
    }

    // Uses a mocked up version of DBSet
    public class TestPatientSet : TestDbSet<Patient>
    {
        public override Patient Find(params object[] keyValues)
        {
            return this.SingleOrDefault(p => p.PatientId == (int)keyValues.Single());
        }
    }

    // Uses a mocked up version of DBSet
    public class TestEpisodeSet : TestDbSet<Episode>
    {
        public override Episode Find(params object[] keyValues)
        {
            return this.SingleOrDefault(e => e.EpisodeId == (int)keyValues.Single());
        }
    }
}