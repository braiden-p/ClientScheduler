# Client Scheduler App

A Windows Forms application for managing client appointments and customer data with secure login, dynamic reports, and an intuitive interface. Built with C# and .NET, it uses MySQL to store data, handles times in UTC while displaying in local time.
## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
  - [Login](#login)
  - [Main Screen](#main-screen)
  - [Managing Appointments](#managing-appointments)
  - [Managing Customers](#managing-customers)
  - [Reports](#reports)
- [Technologies](#technologies)


## Introduction

Client Scheduler is a desktop app designed to streamline appointment and customer management for businesses. It features a secure login, a calendar-driven main screen, and detailed reports, with all times stored in UTC but displayed in the user's local time zone. Powered by MySQL, this project highlights my skills in .NET development and database-driven applications.

## Features

- Secure login to protect user access.
- Main screen with a calendar to filter appointments by date range.
- Add, edit, and delete appointments and customer records.
- Reports for appointment types per month, user schedules, and customers by country.
- Time zone handling: stores times in UTC, displays in local time.
- MySQL database for scalable, persistent storage.
- Notifications for todays schedule when the user logs in. 

### Login Screen

![login](https://github.com/user-attachments/assets/e6c4fe9d-1250-4f66-8ce6-edf16ab9a7b1)


### Main Screen

- View all current appointments in a table, showing customer, type, date, and time (in your local time zone).
- Use the **Date Picker Calendar** to select a date range:
  - Click start and end dates to filter appointments.
  - Clear the selection to show all appointments.
- Click **View Appointments** or **View Customers** to create new records.

![home](https://github.com/user-attachments/assets/41b2a80d-9cd8-475f-9281-ea51ab6ed91f)


### Managing Appointments

- **Add**: Click **Add Appointment**, enter customer ID, type, date, time (local time), and details. Click **Save**. Time is converted to UTC for storage.
- **Edit**: Select an appointment, click **Edit**, update fields, and click **Save**.
- **Delete**: Select an appointment, click **Delete**, and confirm.
- *Note*: Appointments must fall within business hours (stored in UTC).

![addAppointment](https://github.com/user-attachments/assets/c7614811-90d6-4f8e-9648-3ccfd1741638)


### Viewing Customers

- **Add**: Click **Add Customer**, enter name, address, phone, and country. Click **Save Changes**.
- **Modify**: Select a customer, click **Modify**, update details, and click **Save Changes**.
- **Delete**: Select a customer, click **Delete**, and confirm.

![addCust](https://github.com/user-attachments/assets/caf01d93-dfd9-43c4-ba3b-4744fd391c99)


### Reports

- From the main screen, click **Reports** to open the Reports screen.
- Choose a report type:
  - **Appointment Types per Month**: Shows counts by type (e.g., consultation, follow-up) for a selected month.
  - **User Schedules**: Lists appointments by user for a selected date range.
  - **Customers by Country**: Displays customer counts grouped by country.

![report](https://github.com/user-attachments/assets/35652963-8358-4f2d-b630-10c97f0eeca1)


## Technologies

- C# 
- Entity Core
- MySQL 

