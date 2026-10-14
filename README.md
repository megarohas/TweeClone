# TweeClone

A small Twitter-like social network built with ASP.NET MVC 5 as a university
project.

## Features

- Registration and login (login + password, session-based).
- Personal page with your avatar and your posts, newest first.
- Writing posts: text plus any number of attached images.
- Avatar upload (one per user; a new upload replaces the old one).
- List of all registered users with their avatars.
- User pages with Subscribe / Unsubscribe buttons.
- Feed with posts from the users you are subscribed to, including author
  avatars and attached images shown in a jQuery gallery.

Avatars and post images are stored in the database as binary data. The UI is
in Russian.

## Tech

- C#, .NET Framework 4.5.2, ASP.NET MVC 5.2 with Razor views
- Entity Framework 6 (code first) on SQL Server
- Bootstrap 3, jQuery
- Repository interfaces in `WebApp/Abstract`, EF implementations in
  `WebApp/Data`, a minimal session-based `SecurityService` in
  `WebApp/Services`

## Build and run

1. Open `WebApp.sln` in Visual Studio (originally Visual Studio 2015) with
   ASP.NET web development support.
2. In `WebApp/Web.config`, point the `EFDbContext` connection string to your
   SQL Server instance (it targets a SQL Server Express instance on the
   author's old machine). Entity Framework creates the database on first use.
3. Restore NuGet packages if needed (a `packages/` folder is included) and run
   with F5 (IIS Express).

## Limitations

A learning project, not meant to be deployed: passwords are stored and
compared in plain text, there is no CSRF protection and there are no tests.

## Context

University project, Omsk State University, 2016 (first commit 2016-10-12,
published on GitHub in 2019).
