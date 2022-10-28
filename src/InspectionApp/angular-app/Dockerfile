#stage 1
# FROM node:latest as node
# WORKDIR /app
# COPY . .
# RUN npm install
# RUN npm install -g @angular/cli@latest
# RUN ng serve
#stage 2
# FROM nginx:alpine
# COPY --from=node /app/dist/angular13-inspection-api /usr/share/nginx/html
# ENTRYPOINT ["ng", "serve"]

FROM node:14-alpine
WORKDIR /app
RUN npm install -g @angular/cli
COPY . .
RUN npm install
EXPOSE 4200 49153
CMD ng serve --host 0.0.0.0