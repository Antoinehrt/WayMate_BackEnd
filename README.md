# WayMate — Back-end

**WayMate is the back-end for a final-year project of a carpooling (ridesharing) web application and mobile application. This repository implements the APIs, business logic and persistence for user accounts, ride offers, bookings and ratings.**

Table of contents

- Overview
- Features
- Tech stack
- Project Architecture
- Quick start
- API overview

## Overview

- **Purpose**: provide a robust REST API to support a frontend mobile/web client for discovering rides, creating offers, booking seats and rating drivers/passengers.
- **Intended audience**: examiners and future maintainers of the final-year project.

## Features

- User authentication and profile management (JWT)
- Create, read, update, delete ride offers
- Search rides by origin/destination/time
- Booking management (reserve/cancel seats)
- Ride status and simple notifications
- Reviews and ratings for rides and users
- Role basics: rider/driver (extendable)

## Tech stack

- C# ASP.Net Core
- MySQL
- JWT for authentication
- Docker + docker-compose (optional) for local DB

## Project Architecture

```bash
/WayMate_Backend
    /WayMate.Api
    /WayMate.Application
    /WayMate.Domain
    /WayMate.Infrastructure
    /WayMate.Tests
docker-compose.yml
README.md
```

## Quick start

1. Clone the repository
    - git clone [https://github.com/Antoinehrt/WayMate_BackEnd.git](https://github.com/Antoinehrt/WayMate_BackEnd.git)
2. Move to the project directory
    - cd WayMate_BackEnd
3. Create environment file
    - cp .env.example .env and edit values
4. Start the database
    - docker-compose up -d

## API overview (examples)

- Auth
  - POST /api/auth/register — create account
  - POST /api/auth/login — obtain JWT
  - POST /api/auth/refresh — refresh token
- Users
  - GET /api/users/:id — get profile
  - PATCH /api/users/:id — update profile
- Rides
  - POST /api/rides — create ride offer
  - GET /api/rides — list/search rides (query params: origin, destination, date)
  - GET /api/rides/:id — ride details
  - PATCH /api/rides/:id — update ride
  - DELETE /api/rides/:id — cancel ride
- Bookings
  - POST /api/rides/:id/book — create booking
  - PATCH /api/bookings/:id — update (cancel, confirm)
  - GET /api/users/:id/bookings — user bookings
- Reviews
  - POST /api/rides/:id/reviews — submit review
  - GET /api/users/:id/reviews — get user reviews
