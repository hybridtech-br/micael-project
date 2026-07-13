FROM node:20-alpine
WORKDIR /app
COPY package.json ./
COPY src ./src
COPY public ./public
RUN mkdir -p data
EXPOSE 3000
CMD ["npm","start"]
