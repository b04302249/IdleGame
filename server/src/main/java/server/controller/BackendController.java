package server.controller;

import org.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import server.User;
import server.services.UserService;

import java.util.Optional;

@RestController
@RequestMapping(path = "/user")
public class BackendController {

    private final UserService userService;

    @Autowired
    public BackendController(UserService userService){
        this.userService = userService;
    }

    @GetMapping("/all")
    public String getUserTest(){
        JSONObject jsonObject = new JSONObject();
        Optional<User> u1 = userService.getUser("testUser_1");
        if (u1.isEmpty())
            return jsonObject.toString();
        jsonObject.put("userName", u1.get().getUserName());
        jsonObject.put("nickName", u1.get().getNickName());
        jsonObject.put("password", u1.get().getPassword());
        return jsonObject.toString();
    }

    @GetMapping("/{id}")
    public String getUser(@PathVariable String id){
        JSONObject jsonObject = new JSONObject();
        Optional<User> u1 = userService.getUser(Long.valueOf(id));
        if (u1.isEmpty())
            return jsonObject.toString();
        jsonObject.put("userName", u1.get().getUserName());
        jsonObject.put("nickName", u1.get().getNickName());
        jsonObject.put("password", u1.get().getPassword());
        return jsonObject.toString();
    }

}
