<h1 align="center">Master Chef</h1>
<h4 align="center">The Taste is everything...</h3>
<p align="center"><a href="https://telerikacademy.com"><img src="http://i67.tinypic.com/10hruox.png" /></a></p>

### Covered Requirements
  - Used Technology - ASP.NET Web Forms
  - Used Server-side Web Form controls
  - Used MS SQL Server as database back-end - Entity Framework
  - Used model data-binding technique
  - Used 7 data grids with server-side paging and sorting
    - **Administration** (5 - with Edit/Delete options) - Users, Recipes, Articles, Countries and Images Grids
    - **Browse** (2 - with Filter options) - Browsing Recipes and Articles
  - Used Bootstrap for creating beautiful and responsive UI
<p align="center"><a href="https://telerikacademy.com"><img src="http://i65.tinypic.com/xmskrt.png" /></a></p>

  - Used a Master page to define the common UI for the **public**, **private** and **administrative** parts
    - **Public** - everyone can browse articles and recipes
    - **Private** - each registered user can add new recipes, comments to articles, give likes, update their profiles, see the full article
    - **Administrative** - admin can edit/delete users, recipes, articles, countries and images. Can create new articles.
  - Used site navigation
  - Used ASP.NET Identity System for managing users and roles (two type of roles: user and admin)
  - Used *UpdatePanel* on Recipes/Articles browse. 
  - Used *AJAX* in Likes/Comments custom controls
  - Used 4 ASCX user controls: **Comments**, **Likes**, **File Upload** and **Newest Articles** (used in home page)
  - Used file uploading on creating new user, recipe and article
  - Used caching on home page (newest articles field)
  - Used error handling - creating user, recipe, article and etc. 
    - Custom pages for **404** and **403**
  - Escaping HTML characters where is possible. Using regex for validate input
