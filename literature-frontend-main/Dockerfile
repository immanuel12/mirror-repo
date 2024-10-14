FROM node:14-alpine

WORKDIR apps

COPY . .

EXPOSE 3000

CMD ["pm2-runtime", "ecosystem.config.js"]
