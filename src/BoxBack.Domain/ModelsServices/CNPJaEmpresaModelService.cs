using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using BoxBack.Domain.Models.Services;

namespace BoxBack.Domain.ModelsServices
{
    public class CNPJaEmpresaModelService
    {
        public DateTime updated { get; set; }
        public string taxId { get; set; }
        public string alias { get; set; }
        public string founded { get; set; }
        public bool head { get; set; }
        public Company company { get; set; }
        public string statusDate { get; set; }
        public Status status { get; set; }
        public Address address { get; set; }
        public List<Phone> phones { get; set; }
        public List<Email> emails { get; set; }
        public MainActivity mainActivity { get; set; }
        public List<SideActivity> sideActivities { get; set; }
    }

    public class Address
    {
        public int municipality { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string details { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public Country country { get; set; }
    }

    public class Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public int equity { get; set; }
        public Nature nature { get; set; }
        public Size size { get; set; }
        public List<Member> members { get; set; }
    }

    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Email
    {
        public string address { get; set; }
        public string domain { get; set; }
    }

    public class MainActivity
    {
        public int id { get; set; }
        public string text { get; set; }
    }

    public class Member
    {
        public string since { get; set; }
        public Person person { get; set; }
        public Role role { get; set; }
    }

    public class Nature
    {
        public int id { get; set; }
        public string text { get; set; }
    }

    public class Person
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string taxId { get; set; }
        public string age { get; set; }
    }

    public class Phone
    {
        public string area { get; set; }
        public string number { get; set; }
    }

    public class Role
    {
        public int id { get; set; }
        public string text { get; set; }
    }

    public class SideActivity
    {
        public int id { get; set; }
        public string text { get; set; }
    }

    public class Size
    {
        public int id { get; set; }
        public string acronym { get; set; }
        public string text { get; set; }
    }

    public class Status
    {
        public int id { get; set; }
        public string text { get; set; }
    }
}