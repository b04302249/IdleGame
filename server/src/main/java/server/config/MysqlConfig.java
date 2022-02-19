package server.config;

import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import server.User;
import server.repository.UserRepository;

import java.util.List;

@Configuration
public class MysqlConfig {

    // can do some data injection here
    @Bean
    CommandLineRunner commandLineRunner(UserRepository userRepository){
        return strings ->{
            /*
            User testUser = new User("testUser_1");
            User testUser2 = new User("testUser_2");
            List<User> userList = List.of(testUser, testUser2);
            userRepository.saveAll(userList);
             */
        };
    }
}
