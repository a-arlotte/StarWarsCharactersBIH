# Build Docker image
docker build -t starwarsapi .

# Run container
docker run -d -p 5000:8080 --name starwarsapi starwarsapi



# Docker Compose

docker compose up


This forces a rebuild of the docker image:

`docker compose up --build`
