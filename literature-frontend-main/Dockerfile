FROM node:14-alpine

WORKDIR apps

COPY . .

RUN npm install pm2 -g

EXPOSE 3000

CMD ["npm", "start"]
