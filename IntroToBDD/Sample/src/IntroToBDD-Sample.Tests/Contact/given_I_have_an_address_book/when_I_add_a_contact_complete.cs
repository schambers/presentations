using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SpecUnit;

namespace IntroToBDD_Sample.Tests.Contact.given_I_have_an_address_book
{
   [Concern("Adding contacts to an address book")]
   public class when_I_add_a_contact : ContextSpecification
   {
      private AddressBook addressBook;

      protected override void Context()
      {
         addressBook = new AddressBook();
      }

      protected override void Because()
      {
         addressBook.AddContact("Sean Chambers", "385-555-1234");
      }

      [Observation]
      public void should_not_be_empty()
      {
         addressBook.Contacts.Count().ShouldNotEqual(0);
      }

      [Observation]
      public void should_contain_new_entry()
      {
         var contact = addressBook.Find("Sean Chambers");
         contact.Name.ShouldEqual("Sean Chambers");
         contact.Phone.ShouldEqual("385-555-1234");
      }

      [Observation]
      public void should_only_have_one_entry()
      {
         addressBook.Contacts.Count().ShouldEqual(1);
      }
   }

   public class Contact
   {
      public string Name { get; set; }
      public string Phone { get; set; }
   }

   public class AddressBook
   {
      private List<Contact> _contacts;

      public AddressBook()
      {
         _contacts = new List<Contact>();
      }

      public void AddContact(string name, string phone)
      {
         _contacts.Add(new Contact{Name = name, Phone = phone});
      }

      public IEnumerable<Contact> Contacts
      {
         get { return _contacts; }
      }

      public Contact Find(string name)
      {
         return _contacts.Where(c => c.Name == name).FirstOrDefault();
      }
   }
}
