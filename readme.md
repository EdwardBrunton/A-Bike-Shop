# Pretext

ABike Service Center, in an effort to digitize their service order management, once entrusted their hopes to WeCanTry Tech Consultants, a company that, despite their enthusiastic name, had a track record of biting off more than they could chew. WeCanTry, known in the industry more for their optimistic sales pitches than for their technical prowess, assured ABike of a sleek, full-stack solution that would catapult the service center into the digital age.

As it turned out, WeCanTry's capabilities were largely confined to backend development, and even that was a generous assessment. Their team, characterized by a blend of overconfidence and underqualification, managed to cobble together a backend system that is barely functional, but adequate for basic functionality. Before they could attempt to tackle the frontend, ABike Service Center, exasperated by missed deadlines and a series of missteps, decided to part ways with the consultancy.

The backend requires integration with a practical interface. ABike Service Center is looking for a skilled and dependable team to resolve the issues caused by WeCanTry's inadequate work and to provide a frontend that is fast and user-friendly for staff.

Your task is to step into this narrative of technological misadventure and be the hero ABike needs. By developing a frontend that is intuitive, robust, and, most importantly, functional, you will rescue ABike from the aftermath of WeCanTry's well-intentioned but clumsy endeavors. The prioritized features list is your blueprint to rectify past errors and to provide ABike with the digital tools they need to succeed.

# Task

Your task is to create a frontend interface for an existing backend system, prioritizing the implementation of features in the order listed below.

## Features:

1. **List Orders:** Display a list of all open orders when the application is opened.
2. **Create Order:** Provide a form to input and submit new orders.
3. **Show Details:** Allow users to view the details of an order when selected.
4. **Complete Order:** Offer a mechanism to mark orders as completed and remove them from the open orders list.
5. **List Completed:** Show a separate list or section for orders that have been completed.

## Detailed Functional Requirements

### 1. List Open Orders

- The homepage should automatically show all open orders.
- Users must be able to select an order to view more detailed information.

### 2. Create Order

- Include a form for staff to create new bike service orders with the following fields:
  - **Service Type**
    - Wheel adjustment
    - Chain replacement
    - Brake maintenance
  - **Customer Name**
  - **Phone Number**
  - **Email Address**
  - **Bike Brand**
  - **Due Date** (for service completion)
  - **Notes** (for any additional information)

### 3. Show Details

- Detailed information for each order should be easily accessible and clearly presented.

### 4. Complete Order

- Implement a feature to mark an order as 'Complete'.
- Once completed, the order should be removed from the list of open orders.

### 5. List Completed

- Ensure there is a functionality to view all completed orders, separate from open orders.

# How to run the project:

## Dev container

When opening the project in VS Code, you will be prompted to open the project in a dev container. This will automatically set up the development environment for you. If you do not see this prompt, you can manually open the project in a dev container by selecting the option from the command palette (ctrl/cmd+shift+p) and searching for "Dev Containers: Rebuild and Reopen in Container". Docker is required for this to work.

## Frontend

```cmd
cd frontend

npm run dev
```

## Backend

```cmd
cd backend/ABikeApi

dotnet run
```
