# 📊 BÁO CÁO TIẾN ĐỘ NGÀY [16/04/2026]

**Anh @Chibao, em xin báo cáo nghiên cứu:**

## 🚀 Today
- Tổng quan về NoSQL và MongoDB  
- Cài đặt MongoDB  
- Thực hiện demo CRUD Menu-News  

Em xin báo cáo hết.

---

# 🧠 MONGO DB COMMAND

## 1. Authentication
```js
use admin
db.auth("username","password")
```

---

## 2. Create Database
```js
use blog
```

---

## 3. Create Collection
```js
db.createCollection("posts")
```

---

## 4. Insert Documents

### insertOne()
```js
db.posts.insertOne({
  title: "Post Title 1",
  body: "Body of post.",
  category: "News",
  likes: 1,
  tags: ["news", "events"],
  date: Date()
})
```

### insertMany()
```js
db.posts.insertMany([
  {
    title: "Post Title 2",
    body: "Body of post.",
    category: "Event",
    likes: 2,
    tags: ["news", "events"],
    date: Date()
  },
  {
    title: "Post Title 3",
    body: "Body of post.",
    category: "Technology",
    likes: 3,
    tags: ["news", "events"],
    date: Date()
  },
  {
    title: "Post Title 4",
    body: "Body of post.",
    category: "Event",
    likes: 4,
    tags: ["news", "events"],
    date: Date()
  }
])
```

---

## 5. Find Data

### find()
```js
db.posts.find()
```

### findOne()
```js
db.posts.findOne()
db.posts.find({ category: "News" })
```

### Projection
```js
db.posts.find({}, { title: 1, date: 1 })
db.posts.find({}, { _id: 0, title: 1, date: 1 })
```

---

## 6. Update Document

### updateOne()
```js
db.posts.updateOne(
  { title: "Post Title 1" },
  { $set: { likes: 2 } }
)
```

### Upsert (Insert if not found)
```js
db.posts.updateOne(
  { title: "Post Title 5" },
  {
    $set: {
      title: "Post Title 5",
      body: "Body of post.",
      category: "Event",
      likes: 5,
      tags: ["news", "events"],
      date: Date()
    }
  },
  { upsert: true }
)
```

### updateMany()
```js
db.posts.updateMany({}, { $inc: { likes: 1 } })
```

---

## 7. Delete Documents

### deleteOne()
```js
db.posts.deleteOne({ title: "Post Title 5" })
```

### deleteMany()
```js
db.posts.deleteMany({ category: "Technology" })
```

---

## 8. MongoDB Query Operators

### Comparison
- `$eq`: Values are equal  
- `$ne`: Values are not equal  
- `$gt`: Greater than  
- `$gte`: Greater than or equal  
- `$lt`: Less than  
- `$lte`: Less than or equal  
- `$in`: Match within array  

### Logical
- `$and`: Both conditions match  
- `$or`: Either condition matches  
- `$nor`: Neither condition matches  
- `$not`: Condition does not match  

### Evaluation
- `$regex`: Regular expression  
- `$text`: Text search  
- `$where`: JavaScript expression  
