﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BiBo.Persons;
using System.Drawing;
using System.Diagnostics;
using BiBo.Exception;

namespace BiBo
{
    partial class Form1
    {
        //click in main tabs in customer
        private void customerImage_Click(object sender, EventArgs e)
        {
            lib.getGuiApi().switchTabTo(Tabs.CUSTOMER);
        }

        private void booksImage_Click(object sender, EventArgs e)
        {
            lib.getGuiApi().switchTabTo(Tabs.BOOK);
        }

        private void borrowImage_Click(object sender, EventArgs e)
        {
            lib.getGuiApi().switchTabTo(Tabs.BORROW);
        }

        //close application
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //delete
        //delete customer which are selected in datagrid view
        private void buttonDeleteSelectedRows_Click(object sender, EventArgs e)
        {
            switch (this.activTab)
            {
                case Tabs.CUSTOMER:
                    lib.getCustomerDAO().DeleteCustomersByIdList();
                    break;
                case Tabs.BOOK:
                    lib.getBookDAO().DeleteBooksByIdList();
                    break;
            }
        }

        //search
        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {

            //@todo if main tab on user
            TextBox self = (TextBox)sender;

            switch (this.activTab)
            {
                case Tabs.CUSTOMER: searchUserTable(self.Text); break;
                case Tabs.BOOK: searchBookTable(self.Text); break;
            }

        }



        //click on user add
        private void buttonUserAdd_Click(object sender, EventArgs e)
        {
            //get values into local vars
            String UserFName = textBoxUserFirstname.Text;
            String UserName = textBoxUserLastname.Text;

            String Street = textBoxUserStreet.Text;
            String StreetNumber = textBoxUserHomeNumber.Text;
            String StreetExtention = textBoxUserAdressExtention.Text;

            DateTime Birthday = dateTimePickerAddUser.Value;

            String zipCode = textBoxUserPLZ.Text;

            String City = textBoxUserCity.Text;
            String Country = comboBoxUserCountries.SelectedValue + "";

            //set all textboxes background to white
            whilteUserAddInputs();

            Button su = (Button)sender;

            if (!Validation.validateCustomerAddPanel(su.Parent))
            {
                return;
            }

           

            if (su.Text == "hinzufügen")
            {
                 Customer dummy = new Customer(
                   0,
                   UserFName,
                   UserName,
                   Birthday
                );

                //init dummy
                dummy.Street = Street;
                dummy.StreetNumber = StreetNumber;
                dummy.AdditionalRoad = StreetExtention;
                dummy.ZipCode = zipCode;
                dummy.Town = City;
                dummy.Country = Country;
                lib.getCustomerDAO().AddCustomer(dummy);
            }
            else
            {
                Customer newCustomer = new Customer(
                   this.selectedUser.CustomerID,
                   UserFName,
                   UserName,
                   Birthday
                );

                //init dummy
                newCustomer.Street = Street;
                newCustomer.StreetNumber = StreetNumber;
                newCustomer.AdditionalRoad = StreetExtention;
                newCustomer.ZipCode = zipCode;
                newCustomer.Town = City;
                newCustomer.Country = Country;
                MessageBox.Show(newCustomer.ToString());
                CustomerAddEditToggle();
                //@todo update customer by DAO
            }

            //make textboxes for add user empty
            clearUserAddFrom();
        }

        private void CustomerAddEditToggle()
        {
            if(this.buttonUserAdd.Text == "bearbeiten"){
                this.UserAddPanel.BackColor = SystemColors.Control;
                this.clearCancel.Text = "Leeren";
                this.buttonUserAdd.Text = "hinzufügen";
            }else{
                this.UserAddPanel.BackColor = SystemColors.ControlLight;
                this.buttonUserAdd.Text = "bearbeiten";
                this.clearCancel.Text = "abbrechen";
            }
        }

        //add book to SQLLite Table
        private void addBooksActionButton_Click(object sender, EventArgs e)
        {

            //author
            String author = this.textBoxBookAddauthor.Text;
            String title = this.textBoxBookAddTitel.Text;
            String genre = this.textBoxBookAddsubjectArea.Text;

            //all textboxes to white
            textBoxBookAddauthor.BackColor = Color.White;
            textBoxBookAddTitel.BackColor = Color.White;
            textBoxBookAddsubjectArea.BackColor = Color.White;

            if (Validation.isEmpty(author))
            {
                textBoxBookAddauthor.BackColor = Color.Red;
                return;
            }

            if (Validation.isEmpty(title))
            {
                textBoxBookAddTitel.BackColor = Color.Red;
                return;
            }

            if (Validation.isEmpty(genre))
            {
                textBoxBookAddsubjectArea.BackColor = Color.Red;
                return;
            }



            lib.getBookDAO().AddBook(new Book(0, author, title, genre));
            clearBookAddForm();

        }


        //event by clicking cell this selects all cells in rows
        private void userTableDataSet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //make all cells selected, so that it looks like the row is selected
            for (int i = 0; i < userTableDataSet.Rows[e.RowIndex].Cells.Count; i++) //IndexOutOfBoundException wenn man in der Tabelle auf de koopf klickt zum sortieren --> Marcus
            {
                userTableDataSet.Rows[e.RowIndex].Cells[i].Selected = true;
            }

            //get  current user id and pass to show details method
            ulong custId = (ulong)Convert.ToInt64(userTableDataSet.Rows[e.RowIndex].Cells[1].Value.ToString());
            Customer currCustomer = lib.getCustomerDAO().GetCustomerById(custId);
            displayCustomerDetails(currCustomer);
            this.selectedUser = currCustomer;
        }

        //login
        private void login_Click(object sender, EventArgs e)
        {
            Control container = ((Control)sender).Parent;
            String sid = container.Controls.Find("UserLoginName", true)[0].Text;
            String pass = container.Controls.Find("UserLoginPass", true)[0].Text;

            lib.getCustomerDAO().GetAllCustomer();

            ulong id;
            Customer potentialUser;

            if (Validation.isNumeric(sid))
            {
                id = (ulong)Convert.ToInt64(sid);
            }
            else
            {
                MessageBox.Show("Die ID muss eine Zahl sein");
                return;
            }

            try
            {
                potentialUser = lib.getCustomerDAO().GetCustomerById(id);
            }
            catch (CustomerNotFoundException err)
            {
                MessageBox.Show(err.Message);
                return;
            }

            //@todo check password

            //@todo remove (force some rights)
            if(potentialUser.CustomerID == 103){
                potentialUser.Right = Rights.ADMINISTRATOR;
            }


            if (potentialUser != null)
            {
                if (potentialUser.UserState == UserStates.DELETED)
                {
                    MessageBox.Show("Dieser Benuter wurde aus dem System entfernt. Bitte wenden Sie sich an die Rezeption");
                    return;
                }
                if (potentialUser.UserState == UserStates.BANNED)
                {
                    MessageBox.Show("Dieser Benuter ist gesperrt. Bitte wenden Sie sich an die Rezeption");
                    return;
                }

                switch (potentialUser.Right)
                {
                    case Rights.CUSTOMER:
                        this.UserLogin(potentialUser);
                        break;
                    case Rights.EMPLOYEE:
                        this.EmployeeLogin(potentialUser);
                        break;
                    case Rights.ADMINISTRATOR:
                        this.AdminLogin(potentialUser);
                        break;

                }


            }

            return;

        }

    

        private void CustomerSearchBook_KeyUp(object sender, EventArgs e)
        {
            String search = ((TextBox)sender).Text.ToUpper();

            for (int i = 0; i < customerSearchBook.Rows.Count; i++)
            {
                customerSearchBook.Rows[i].Visible = (this.checkBoxCustomerSearchAutor.Checked && 
                                                        customerSearchBook.Rows[i].Cells[1].Value.ToString().ToUpper().Contains(search)) ||
                                                     (this.checkBoxCustomerSearchTitle.Checked &&
                                                        customerSearchBook.Rows[i].Cells[2].Value.ToString().ToUpper().Contains(search));                
            }
        }

        private void imageSearch_Click(object sender, EventArgs e)
        {
            this.customerSearchBookPanel.Visible = true;
            this.customerAccountPanel.Visible = false;

        }

        private void imageAccount_Click(object sender, EventArgs e)
        {
            this.customerSearchBookPanel.Visible = false;
            this.customerAccountPanel.Visible = true;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.SuperPanelCustomer.Visible = false;
            this.SuperPanelLogin.Visible = true;
        }

        private void EmployeeLogout_Click(object sender, EventArgs e)
        {
            this.SuperPanelEmployee.Visible = false;
            this.SuperPanelLogin.Visible = true;
        }

        private void EditUser_Click(object sender, EventArgs e){
            if (this.selectedUser != null)
            {
                this.textBoxUserFirstname.Text = this.selectedUser.FirstName;
                this.textBoxUserLastname.Text = this.selectedUser.LastName;
                this.dateTimePickerAddUser.Value = this.selectedUser.BirthDate;
                this.textBoxUserStreet.Text = this.selectedUser.Street;
                this.textBoxUserHomeNumber.Text = this.selectedUser.StreetNumber;
                this.textBoxUserAdressExtention.Text = this.selectedUser.AdditionalRoad;
                this.textBoxUserPLZ.Text = this.selectedUser.ZipCode;
                this.textBoxUserCity.Text = this.selectedUser.Town;
                //@todo this.comboBoxUserCountries

                CustomerAddEditToggle();
            }
        }

        private void clearCancel_Click(object sender, EventArgs e)
        {
            Button self = (Button)sender;

            if (self.Text != "Leeren"){
                CustomerAddEditToggle();
            }
            clearUserAddFrom();
        }

        private void borrowCustomerIDTextBox_KeyUp(object sender, KeyEventArgs ke)
        {
            String value = ((TextBox)sender).Text;
            this.borrowCustomerInfoLabel.Text = "";
            this.imageCustomerCardValidation.BackgroundImage = null;
            if (value.Trim() == "")
            {
                this.imageCustomerFound.BackgroundImage = null;
                return;
            }
            if (Validation.isNumeric(value))
            {
                try
                {
                    Customer x = lib.getCustomerDAO().GetCustomerById((ulong)Convert.ToInt64(value));
                    //test: x.UserState = UserStates.BANNED;
                    this.borrowCustomerInfoLabel.Text = x.FirstName + " " + x.LastName + " " + x.Street + " " + x.StreetNumber + " " +
                        x.ZipCode + " " + x.Town;
                    this.imageCustomerFound.BackgroundImage = global::BiBo.Properties.Resources.user_found;

                    if (x.UserState == UserStates.ACTIVE)
                    {
                        this.imageCustomerCardValidation.BackgroundImage = global::BiBo.Properties.Resources.card_valid;
                        return;
                    }

                    this.imageCustomerCardValidation.BackgroundImage = global::BiBo.Properties.Resources.card_invalid;
                    return;
                }
                catch (CustomerNotFoundException cnfe)
                {
                    this.borrowCustomerInfoLabel.Text = cnfe.Message;
                }
            }
           
            this.imageCustomerFound.BackgroundImage = global::BiBo.Properties.Resources.user_not_found;
            
            
        }

        
    }
 
  }
