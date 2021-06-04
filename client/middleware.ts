module.exports = (req, res, next) => {
    res.header("Content-Range","funcionarios 0-5/10");
    next();
};
