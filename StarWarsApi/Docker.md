# Build Docker image
docker build -t starwarsapi .

# Run container
docker run -d -p 5000:8080 --name starwarsapi starwarsapi
