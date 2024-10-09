# Use an official Node.js runtime as a parent image
FROM node:14

# Set the working directory
WORKDIR /usr/src/app

# Copy the package.json and package-lock.json files
COPY package*.json ./

# Copy the rest of the application
COPY . .

# Expose port 3001
EXPOSE 3001

# Command to run the application
CMD [ "npm", "start" ]